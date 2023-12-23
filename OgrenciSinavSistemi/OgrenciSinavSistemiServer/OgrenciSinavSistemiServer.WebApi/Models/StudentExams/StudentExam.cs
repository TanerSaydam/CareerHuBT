using OgrenciSinavSistemiServer.WebApi.Models.Exams;

namespace OgrenciSinavSistemiServer.WebApi.Models.UserExams;

public sealed class StudentExam
{
    public Guid UserId { get; set; }
    public Guid ExamId { get; set; }
    public Exam? Exam { get; set; }
    public bool IsExamFinish { get; set; } = false;
}
