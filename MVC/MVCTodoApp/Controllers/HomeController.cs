using Microsoft.AspNetCore.Mvc;

namespace MVCTodoApp.Controllers;
public class HomeController : Controller
{
    private static List<Todo> Todos = new();
    
    public IActionResult Index()
    {
        return View(Todos);
    }

    [HttpGet]
    public JsonResult Save(string work)
    {
        Todo todo = new()
        {
            Work = work
        };

        Todos.Add(todo);


        return Json(todo);
    }

    [HttpGet]
    public JsonResult Remove(string id)
    {
        Todos.Remove(Todos.FirstOrDefault(p => p.Id == Guid.Parse(id)));

        return Json(true);
    }
}
public sealed class Todo
{
    public Todo()
    {
        Id = Guid.NewGuid();
        IsCompleted = false;
        CreatedDate = DateTime.Now;
    }
    public Guid Id { get; set; }
    public string Work { get; set; }
    public bool IsCompleted { get; set; }  
    public DateTime CreatedDate { get; set; }
}
