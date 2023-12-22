using OgrenciSinavSistemiServer.WebApi.Context;

namespace OgrenciSinavSistemiServer.WebApi.Models.UserExams;

public sealed class UserExamRepository(ApplicationDbContext context) : IUserExamRespoitory
{
    public async Task AddRangeAsync(List<UserExam> userExams, CancellationToken cancellationToken = default)
    {
        await context.UserExams.AddRangeAsync(userExams, cancellationToken);
    }
}
