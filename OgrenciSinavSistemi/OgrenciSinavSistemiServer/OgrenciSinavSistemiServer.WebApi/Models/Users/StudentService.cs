using ErrorOr;
using Microsoft.EntityFrameworkCore;
using OgrenciSinavSistemiServer.WebApi.Abstractions;
using OgrenciSinavSistemiServer.WebApi.DTOs;

namespace OgrenciSinavSistemiServer.WebApi.Models.Users;

public sealed class StudentService(
    IUserRepository userRepository,
    IUnitOfWork unitOfWork) : IStudentService
{
    public async Task<ErrorOr<Guid>> CreateAsync(CreateStudentDto request, CancellationToken cancellationToken = default)
    {
        User? user = await userRepository.GetByUserNameAsync(request.UserName, cancellationToken);

        if (user is not null)
        {
            return Error.Conflict("UserNameAlreadyExists", "Bu kullanıcı adı daha önce kullanılmış!");
        }

        user = new()
        {
            Name = request.Name,
            UserName = request.UserName,
            IsTeacher = false
        };

        await userRepository.CreateAsync(user, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return user.Id;
    }

    public async Task<ErrorOr<IEnumerable<User>>> GetAllStudentAsync(CancellationToken cancellationToken = default)
    {
        return await userRepository.GetAll().Where(p => !p.IsTeacher).OrderBy(p => p.Name).ToListAsync(cancellationToken);
    }
}
