using ErrorOr;
using OgrenciSinavSistemiServer.WebApi.DTOs;
using OgrenciSinavSistemiServer.WebApi.Models.Exams;

namespace OgrenciSinavSistemiServer.WebApi.Models.StudentExamQuestions;

public interface IStudentExamQuestionService
{
    Task<ErrorOr<Guid>> AnswerTheQuestionAsync(AnswerTheQuestionDto request, Guid studentId, CancellationToken cancellationToken = default);
    Task<ErrorOr<List<ExamDto>?>> GetAllByStudentId(Guid guid, CancellationToken cancellationToken);
    Task<ErrorOr<List<ExamQuestion>>> GetExamQuestionsByExamIdAsync(Guid examId, CancellationToken cancellationToken);
    Task<ErrorOr<Guid>> StartExamByExamIdAsync(Guid examId, Guid studentId,CancellationToken cancellationToken);
}
