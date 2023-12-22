using ErrorOr;
using OgrenciSinavSistemiServer.WebApi.Abstractions;
using OgrenciSinavSistemiServer.WebApi.DTOs;

namespace OgrenciSinavSistemiServer.WebApi.Models.UserExams;

public sealed class UserExamService(
    IUserExamRespoitory userExamRespoitory,
    IUnitOfWork unitOfWork) : IUserExamService
{
    public async Task<ErrorOr<int>> AddRangeAsync(AddUserExamRangeDto request, CancellationToken cancellationToken = default)
    {
        List<UserExam> userExams = new();
        foreach (var studentId in request.StudentIds)
        {
            UserExam userExam = new()
            {
                ExamId = request.ExamId,
                UserId = studentId
            };
            userExams.Add(userExam);
        }

        await userExamRespoitory.AddRangeAsync(userExams, cancellationToken);
        var result = await unitOfWork.SaveChangesAsync(cancellationToken);
        return result;
    }
}
