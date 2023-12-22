namespace OgrenciSinavSistemiServer.WebApi.Models.UserExams;

public interface IUserExamRespoitory
{
    Task AddRangeAsync(List<UserExam> userExams, CancellationToken cancellationToken = default);
}
