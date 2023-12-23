namespace OgrenciSinavSistemiServer.WebApi.Models.UserExams;

public interface IStudentExamRepository
{
    Task AddRangeAsync(List<StudentExam> userExams, CancellationToken cancellationToken = default);
    IQueryable<StudentExam> GetAll();
}
