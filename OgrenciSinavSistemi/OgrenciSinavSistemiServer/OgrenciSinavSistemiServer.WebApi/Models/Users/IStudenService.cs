using ErrorOr;
using OgrenciSinavSistemiServer.WebApi.DTOs;

namespace OgrenciSinavSistemiServer.WebApi.Models.Users;

public interface IStudenService
{
    Task<ErrorOr<Guid>> CreateAsync(CreateStudentDto request, CancellationToken cancellationToken = default);
    Task<ErrorOr<List<User>>> GetAllStudentAsync(CancellationToken cancellationToken = default);
}
