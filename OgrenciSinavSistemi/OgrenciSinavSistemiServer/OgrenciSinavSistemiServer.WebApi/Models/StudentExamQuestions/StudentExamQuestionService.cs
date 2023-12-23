using ErrorOr;
using Microsoft.EntityFrameworkCore;
using OgrenciSinavSistemiServer.WebApi.Abstractions;
using OgrenciSinavSistemiServer.WebApi.DTOs;
using OgrenciSinavSistemiServer.WebApi.Models.Exams;
using OgrenciSinavSistemiServer.WebApi.Models.UserExams;

namespace OgrenciSinavSistemiServer.WebApi.Models.StudentExamQuestions;

public sealed class StudentExamQuestionService(
    IStudentExamRepository studentExamRepository,
    IExamQuestionRepository examQuestionRepository,
    IStudentExamQuestionRepository studentExamQuestionRepository, 
    IUnitOfWork unitOfWork) : IStudentExamQuestionService
{
    public async Task<ErrorOr<Guid>> AnswerTheQuestionAsync(AnswerTheQuestionDto request, Guid studentId, CancellationToken cancellationToken = default)
    {
        var isStudentAnswerThisQuestion = await studentExamQuestionRepository.IsTheQuestionAlreadyAnswer(request.ExamQuestionId, studentId, cancellationToken);

        if (isStudentAnswerThisQuestion)
        {
            return Error.Conflict("Bu soru daha önce cevaplanmış!");
        }

        StudentExamQuestion studentExamQuestion = new()
        {
            ExamQuestionId = request.ExamQuestionId,
            StudentId = studentId,
            Answer = request.Answer
        };

        await studentExamQuestionRepository.AnswerTheQuestionAsync(studentExamQuestion, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return studentExamQuestion.Id;
    }

    public async Task<ErrorOr<List<ExamQuestion>>> GetExamQuestionsByExamIdAsync(Guid examId, CancellationToken cancellationToken)
    {
        return await examQuestionRepository.GetExamQuestionsByExamIdAsync(examId, cancellationToken);
    }

    public async Task<ErrorOr<List<ExamDto>?>> GetAllByStudentId(Guid guid, CancellationToken cancellationToken)
    {
        var studentExams =
             await studentExamRepository
                 .GetAll()
                 .Include(p => p.Exam)
                 .Where(p => p.UserId == guid)
                 .ToListAsync(cancellationToken);

        var response = studentExams.Select(s => new ExamDto(s.Exam!.Id,s.Exam.Title,s.IsExamFinish)).ToList();

        return response;
    }

    public async Task<ErrorOr<Guid>> StartExamByExamIdAsync(Guid examId, Guid studentId, CancellationToken cancellationToken)
    {
        var studentExam = await studentExamRepository.GetAll().Where(p => p.ExamId == examId && p.UserId == studentId).FirstOrDefaultAsync(cancellationToken);

        if(studentExam is not null)
        {
            studentExam.IsExamFinish = true;
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }

        return examId;
    }
}
