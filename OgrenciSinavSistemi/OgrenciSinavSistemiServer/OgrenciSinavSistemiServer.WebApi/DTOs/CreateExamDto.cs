namespace OgrenciSinavSistemiServer.WebApi.DTOs;

public sealed record CreateExamDto(
    string Title,
    List<CreateExamQuestionDto> ExamQuestions);

public sealed record CreateExamQuestionDto(
    string Question,
    string AnswerA,
    string AnswerB,
    string AnswerC,
    string AnswerD,
    char CorrectAnswer);
