namespace OgrenciSinavSistemiServer.WebApi.Models;

public sealed class Exam
{
    public Exam()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
}
