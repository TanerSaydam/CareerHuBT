namespace OgrenciSinavSistemiServer.WebApi.Models.Exams;

public sealed class Exam
{
    public Exam()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public List<ExamQuestion>? ExamQuestions { get; set; }
}
