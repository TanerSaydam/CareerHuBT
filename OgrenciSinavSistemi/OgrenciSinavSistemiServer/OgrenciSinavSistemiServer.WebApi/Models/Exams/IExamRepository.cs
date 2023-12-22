using ErrorOr;
using OgrenciSinavSistemiServer.WebApi.Models;

namespace OgrenciSinavSistemiServer.WebApi.Models.Exams;

public interface IExamRepository
{
    Task CreateAsync(Exam exam, CancellationToken cancellationToken = default);
    IQueryable<Exam> GetAll();
}
