using Microsoft.AspNetCore.Mvc;
using OgrenciSinavSistemiServer.WebApi.DTOs;
using OgrenciSinavSistemiServer.WebApi.Models.UserExams;

namespace OgrenciSinavSistemiServer.WebApi.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class UserExamsController(IStudentExamService userExamService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddRange(AddUserExamRangeDto request, CancellationToken cancellationToken)
    {
        var errorOr = await userExamService.AddRangeAsync(request, cancellationToken);

        var response = new ResponseDto<int>() { Data = errorOr.Value };

        return Ok(response);
    }
}
