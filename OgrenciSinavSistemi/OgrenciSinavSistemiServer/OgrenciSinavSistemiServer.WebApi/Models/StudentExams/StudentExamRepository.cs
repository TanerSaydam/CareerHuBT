using OgrenciSinavSistemiServer.WebApi.Context;

namespace OgrenciSinavSistemiServer.WebApi.Models.UserExams;

public sealed class StudentExamRepository(ApplicationDbContext context) : IStudentExamRepository
{
    public async Task AddRangeAsync(List<StudentExam> userExams, CancellationToken cancellationToken = default)
    {
        await context.StudentExams.AddRangeAsync(userExams, cancellationToken);
    }

    public IQueryable<StudentExam> GetAll()
    {
        return context.StudentExams.AsQueryable();
    }
}
