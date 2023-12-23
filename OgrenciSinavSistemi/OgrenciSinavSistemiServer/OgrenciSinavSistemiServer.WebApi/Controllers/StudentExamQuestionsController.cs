using ErrorOr;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OgrenciSinavSistemiServer.WebApi.DTOs;
using OgrenciSinavSistemiServer.WebApi.Models.Exams;
using OgrenciSinavSistemiServer.WebApi.Models.StudentExamQuestions;

namespace OgrenciSinavSistemiServer.WebApi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
[Authorize(AuthenticationSchemes = "Bearer")]
public sealed class StudentExamQuestionsController(
    IStudentExamQuestionService studentExamQuestionService
    ) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetExamsByStudentId(CancellationToken cancellationToken)
    {
        string userId = User.Claims.FirstOrDefault(p => p.Type == "UserId")!.Value;
        ErrorOr<List<ExamDto>?> errorOr = await studentExamQuestionService.GetAllByStudentId(Guid.Parse(userId), cancellationToken);

        var response = new ResponseDto<IEnumerable<ExamDto>?>() { Data = errorOr.Value };

        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetExamQuestionsByExamId(Guid examId, CancellationToken cancellationToken)
    {
        ErrorOr<List<ExamQuestion>> errorOr = await studentExamQuestionService.GetExamQuestionsByExamIdAsync(examId, cancellationToken);

        var response = new ResponseDto<List<ExamQuestion>>() { Data = errorOr.Value };

        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> StartExamByExamId(Guid examId, CancellationToken cancellationToken)
    {
        string userId = User.Claims.FirstOrDefault(p => p.Type == "UserId")!.Value;
        ErrorOr<Guid> errorOr = await studentExamQuestionService.StartExamByExamIdAsync(examId, Guid.Parse(userId),cancellationToken);

        var response = new ResponseDto<Guid>() { Data = errorOr.Value };

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> AnswerTheQuestion(AnswerTheQuestionDto request, CancellationToken cancellationToken)
    {
        string userId = User.Claims.FirstOrDefault(p => p.Type == "UserId")!.Value;

        ErrorOr<Guid> errorOr = await studentExamQuestionService.AnswerTheQuestionAsync(request, Guid.Parse(userId), cancellationToken);

        if(errorOr.IsError)
        {
            return BadRequest(errorOr);
        }

        var response = new ResponseDto<Guid>() { Data = errorOr.Value };

        return Ok(response);
    }
}
