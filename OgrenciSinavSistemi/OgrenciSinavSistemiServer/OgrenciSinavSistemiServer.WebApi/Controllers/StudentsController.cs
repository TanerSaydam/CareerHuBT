using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using OgrenciSinavSistemiServer.WebApi.DTOs;
using OgrenciSinavSistemiServer.WebApi.Models.Users;

namespace OgrenciSinavSistemiServer.WebApi.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class StudentsController
    (IStudenService studentService): ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateStudentDto request, CancellationToken cancellationToken)
    {
        ErrorOr<Guid> response = await studentService.CreateAsync(request, cancellationToken);

        if (response.IsError)
        {
            return BadRequest(response.FirstError);
        }

        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllStudent(CancellationToken cancellationToken)
    {
        var response = await studentService.GetAllStudentAsync(cancellationToken);

        return Ok(response);
    }
}
