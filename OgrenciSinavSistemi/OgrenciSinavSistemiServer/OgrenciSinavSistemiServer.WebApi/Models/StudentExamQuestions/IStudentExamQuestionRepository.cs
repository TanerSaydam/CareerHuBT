namespace OgrenciSinavSistemiServer.WebApi.Models.StudentExamQuestions;

public interface IStudentExamQuestionRepository
{
    Task AnswerTheQuestionAsync(StudentExamQuestion studentExamQuestion, CancellationToken cancellationToken = default);
    Task<bool> IsTheQuestionAlreadyAnswer(int examQuestionId, Guid userId, CancellationToken cancellationToken = default);
}
