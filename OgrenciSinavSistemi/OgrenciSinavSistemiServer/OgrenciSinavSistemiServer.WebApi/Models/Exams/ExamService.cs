using ErrorOr;
using Microsoft.EntityFrameworkCore;
using OgrenciSinavSistemiServer.WebApi.Abstractions;
using OgrenciSinavSistemiServer.WebApi.DTOs;

namespace OgrenciSinavSistemiServer.WebApi.Models.Exams;

public sealed class ExamService(
    IExamRepository examRepository,
    IUnitOfWork unitOfWork) : IExamService
{
    public async Task<ErrorOr<Guid>> CreateAsync(CreateExamDto request, CancellationToken cancellationToken = default)
    {
        List<ExamQuestion> examQuestions = new();
        foreach (var question in request.ExamQuestions)
        {
            ExamQuestion examQuestion = new()
            {
                AnswerA = question.AnswerA,
                AnswerB = question.AnswerB,
                AnswerC = question.AnswerC,
                AnswerD = question.AnswerD,
                CorrectAnswer = question.CorrectAnswer,
                Question = question.Question
            };
            examQuestions.Add(examQuestion);
        }


        Exam exam = new()
        {
            ExamQuestions = examQuestions,
            Title = request.Title
        };

        await examRepository.CreateAsync(exam, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return exam.Id;
    }

    public async Task<ErrorOr<IEnumerable<Exam>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var response = await examRepository.GetAll().ToListAsync(cancellationToken);

        return response;
    }    
}
