using Bogus;
using Elasticsearch.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using ODataAndElasticSearchWebApi.Context;
using ODataAndElasticSearchWebApi.Models;

namespace ODataAndElasticSearchWebApi.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
//Primary constructor
public class ValuesController(ApplicationDbContext context) : ControllerBase
{

    [HttpGet]
    [EnableQuery]
    public IActionResult GetAll()
    {
        var response = context.Users.AsNoTracking().ToList();

        return Ok(response);
    }

    [HttpGet("{value}")]
    public IActionResult GetAllWithEFCore(string value)
    {
        var response = 
            context.Users.AsNoTracking()
            .Where(p=> p.FirstName.ToLower().Contains(value.ToLower()))
            .Take(10)
            .ToList();

        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> SyncToElasticSearch()
    {
        var setting = new ConnectionConfiguration(new Uri("http://localhost:9200"));
        var client = new ElasticLowLevelClient(setting);

        var users = context.Users.AsNoTracking().ToList();

        var task = new List<Task>();

        foreach (var user in users)
        {
            var response = await client.GetAsync<StringResponse>("users", user.Id.ToString());
            if(response.HttpStatusCode == 404)
            {
                task.Add(client.IndexAsync<StringResponse>("users", user.Id.ToString(), PostData.Serializable(new
                {
                    user.Id,
                    user.FirstName,
                    user.LastName,
                    user.Email,
                    user.PhoneNumber,
                    user.AboutMe
                })));
            }
        }

        await Task.WhenAll(task);

        return NoContent();
    }

    [HttpGet("{value}")]
    public async Task<IActionResult> GetAllWithElasticSearch(string value)
    {
        var setting = new ConnectionConfiguration(new Uri("http://localhost:9200"));
        var client = new ElasticLowLevelClient(setting);

        var response = await client.SearchAsync<StringResponse>("users", PostData.Serializable(new
        {
            query = new
            {
                wildcard = new
                {
                    FirstName = new
                    {
                        value = $"*{value.ToLower()}*"
                    }
                }
            }
        }));

        var result = JObject.Parse(response.Body);

        var hits = result["hits"]["hits"].ToObject<List<JObject>>();

        List<User> users = new();

        foreach (var hit in hits)
        {
            users.Add(hit["_source"].ToObject<User>());
        }

        return Ok(users);
    }

    [HttpGet]
    public IActionResult SeedData()
    {
        for (int i = 0; i < 10000; i++)
        {
            Faker faker = new Faker();
            Models.User user = new()
            {
                Email = faker.Person.Email,
                FirstName = faker.Person.FirstName,
                LastName = faker.Person.LastName,
                AboutMe = string.Join(" ", faker.Random.WordsArray(10,150)),
                PhoneNumber = faker.Person.Phone
            };

            context.Users.Add(user);
            context.SaveChanges();
        }

        return NoContent();
    }
}
