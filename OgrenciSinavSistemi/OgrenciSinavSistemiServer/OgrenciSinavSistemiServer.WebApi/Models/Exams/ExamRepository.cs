using OgrenciSinavSistemiServer.WebApi.Context;
using OgrenciSinavSistemiServer.WebApi.Models;

namespace OgrenciSinavSistemiServer.WebApi.Models.Exams;

public sealed class ExamRepository(
    ApplicationDbContext context) : IExamRepository
{
    public async Task CreateAsync(Exam exam, CancellationToken cancellationToken = default)
    {
        await context.Exams.AddAsync(exam, cancellationToken);
    }

    public IQueryable<Exam> GetAll()
    {
        return context.Exams.AsQueryable();
    }
}
