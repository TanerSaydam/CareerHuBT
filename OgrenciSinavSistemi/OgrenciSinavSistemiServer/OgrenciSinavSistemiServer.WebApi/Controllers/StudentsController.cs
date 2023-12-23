using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using OgrenciSinavSistemiServer.WebApi.DTOs;
using OgrenciSinavSistemiServer.WebApi.Models.Users;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OgrenciSinavSistemiServer.WebApi.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class StudentsController
    (IStudentService studentService): ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateStudentDto request, CancellationToken cancellationToken)
    {
        ErrorOr<Guid> errorOr = await studentService.CreateAsync(request, cancellationToken);

        if (errorOr.IsError)
        {
            return BadRequest(errorOr.FirstError);
        }

        var response = new ResponseDto<Guid>() { Data = errorOr.Value };

        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllStudent(CancellationToken cancellationToken)
    {
        var errorOr = await studentService.GetAllStudentAsync(cancellationToken);

        var response = new ResponseDto<IEnumerable<User>>() { Data = errorOr.Value };

        return Ok(response);
    }
}
