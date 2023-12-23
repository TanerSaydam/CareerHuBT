using ErrorOr;
using OgrenciSinavSistemiServer.WebApi.Abstractions;
using OgrenciSinavSistemiServer.WebApi.DTOs;

namespace OgrenciSinavSistemiServer.WebApi.Models.UserExams;

public sealed class StudentExamService(
    IStudentExamRepository userExamRespoitory,
    IUnitOfWork unitOfWork) : IStudentExamService
{
    public async Task<ErrorOr<int>> AddRangeAsync(AddUserExamRangeDto request, CancellationToken cancellationToken = default)
    {
        List<StudentExam> userExams = new();
        foreach (var studentId in request.StudentIds)
        {
            StudentExam userExam = new()
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
