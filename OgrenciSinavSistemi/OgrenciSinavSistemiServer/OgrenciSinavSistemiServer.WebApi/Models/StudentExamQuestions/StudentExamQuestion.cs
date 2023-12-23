namespace OgrenciSinavSistemiServer.WebApi.Models.StudentExamQuestions;

public sealed class StudentExamQuestion
{
    public StudentExamQuestion()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; set; }
    public int ExamQuestionId { get; set; }
    public Guid StudentId { get; set; }
    public char Answer {  get; set; }
}
