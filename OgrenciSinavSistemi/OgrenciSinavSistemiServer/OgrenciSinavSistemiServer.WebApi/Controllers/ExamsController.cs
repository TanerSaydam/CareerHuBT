using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using OgrenciSinavSistemiServer.WebApi.DTOs;
using OgrenciSinavSistemiServer.WebApi.Models.Exams;

namespace OgrenciSinavSistemiServer.WebApi.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public sealed class ExamsController(
    IExamService examService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateExamDto request, CancellationToken cancellationToken)
    {
        ErrorOr<Guid> response = await examService.CreateAsync(request, cancellationToken);       

        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var response = await examService.GetAllAsync(cancellationToken);
        return Ok(response);
    }

    //21:36 görüşelim
}
