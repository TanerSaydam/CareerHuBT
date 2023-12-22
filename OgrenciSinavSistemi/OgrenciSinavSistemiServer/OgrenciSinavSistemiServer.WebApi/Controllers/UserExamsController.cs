using Microsoft.AspNetCore.Mvc;
using OgrenciSinavSistemiServer.WebApi.DTOs;
using OgrenciSinavSistemiServer.WebApi.Models.UserExams;

namespace OgrenciSinavSistemiServer.WebApi.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class UserExamsController(IUserExamService userExamService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddRange(AddUserExamRangeDto request, CancellationToken cancellationToken)
    {
        var response = await userExamService.AddRangeAsync(request, cancellationToken);
        return Ok(response);
    }
}
