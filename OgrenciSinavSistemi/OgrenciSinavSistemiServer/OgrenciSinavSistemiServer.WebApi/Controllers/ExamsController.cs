using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using OgrenciSinavSistemiServer.WebApi.DTOs;
using OgrenciSinavSistemiServer.WebApi.Models.Exams;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OgrenciSinavSistemiServer.WebApi.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public sealed class ExamsController(
    IExamService examService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateExamDto request, CancellationToken cancellationToken)
    {
        ErrorOr<Guid> errorOr = await examService.CreateAsync(request, cancellationToken);

        var response = new ResponseDto<Guid>() { Data = errorOr.Value };

        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var errorOr = await examService.GetAllAsync(cancellationToken);

        var response = new ResponseDto<IEnumerable<Exam>>() { Data = errorOr.Value };

        return Ok(response);
    }   
}
