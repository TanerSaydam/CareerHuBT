namespace OgrenciSinavSistemiServer.WebApi.DTOs;

public sealed record AddUserExamRangeDto(
    Guid ExamId,
    List<Guid> StudentIds);