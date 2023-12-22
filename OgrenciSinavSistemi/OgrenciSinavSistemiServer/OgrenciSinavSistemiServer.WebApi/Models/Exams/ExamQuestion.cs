namespace OgrenciSinavSistemiServer.WebApi.Models.Exams;

public class ExamQuestion
{
    public int Id { get; set; }
    public Guid ExamId { get; set; }
    public string Question { get; set; } = string.Empty;
    public string AnswerA { get; set; } = string.Empty;
    public string AnswerB { get; set; } = string.Empty;
    public string AnswerC { get; set; } = string.Empty;
    public string AnswerD { get; set; } = string.Empty;
    public char CorrectAnswer { get; set; } = 'A';
}
