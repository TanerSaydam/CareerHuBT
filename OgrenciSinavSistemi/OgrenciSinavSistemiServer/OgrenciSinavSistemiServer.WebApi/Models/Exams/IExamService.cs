using ErrorOr;
using OgrenciSinavSistemiServer.WebApi.DTOs;

namespace OgrenciSinavSistemiServer.WebApi.Models.Exams;

public interface IExamService
{
    Task<ErrorOr<Guid>> CreateAsync(CreateExamDto request, CancellationToken cancellationToken = default);
    Task<ErrorOr<List<Exam>>> GetAllAsync(CancellationToken cancellationToken = default);
}
