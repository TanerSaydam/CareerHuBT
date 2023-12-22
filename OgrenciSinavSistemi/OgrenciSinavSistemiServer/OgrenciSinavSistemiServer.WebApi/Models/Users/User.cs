namespace OgrenciSinavSistemiServer.WebApi.Models.Users;

public sealed class User
{
    public User()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public bool IsTeacher { get; set; } = false;
}
