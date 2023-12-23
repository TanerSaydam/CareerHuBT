namespace OgrenciSinavSistemiServer.WebApi.DTOs;

public sealed record ExamDto(
    Guid Id,
    string Title,
    bool IsExamFinish);
