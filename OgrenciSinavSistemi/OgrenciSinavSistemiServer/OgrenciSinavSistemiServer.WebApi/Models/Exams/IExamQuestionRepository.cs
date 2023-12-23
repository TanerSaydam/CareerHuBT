namespace OgrenciSinavSistemiServer.WebApi.Models.Exams;

public interface IExamQuestionRepository
{
    Task<List<ExamQuestion>> GetExamQuestionsByExamIdAsync(Guid examId, CancellationToken cancellationToken = default);
}
