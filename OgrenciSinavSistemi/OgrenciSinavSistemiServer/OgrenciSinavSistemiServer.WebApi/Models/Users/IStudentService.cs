using ErrorOr;
using OgrenciSinavSistemiServer.WebApi.DTOs;

namespace OgrenciSinavSistemiServer.WebApi.Models.Users;

public interface IStudentService
{
    Task<ErrorOr<Guid>> CreateAsync(CreateStudentDto request, CancellationToken cancellationToken = default);
    Task<ErrorOr<IEnumerable<User>>> GetAllStudentAsync(CancellationToken cancellationToken = default);
}
