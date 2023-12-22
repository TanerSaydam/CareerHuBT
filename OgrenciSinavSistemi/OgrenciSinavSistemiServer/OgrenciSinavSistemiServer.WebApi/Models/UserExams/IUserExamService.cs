using ErrorOr;
using OgrenciSinavSistemiServer.WebApi.DTOs;

namespace OgrenciSinavSistemiServer.WebApi.Models.UserExams;

public interface IUserExamService
{
    Task<ErrorOr<int>> AddRangeAsync(AddUserExamRangeDto request, CancellationToken cancellationToken = default);
}
