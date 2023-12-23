using Microsoft.EntityFrameworkCore;
using OgrenciSinavSistemiServer.WebApi.Context;

namespace OgrenciSinavSistemiServer.WebApi.Models.StudentExamQuestions;

public sealed class StudentExamQuestionRepository(ApplicationDbContext context) : IStudentExamQuestionRepository
{
    public async Task AnswerTheQuestionAsync(StudentExamQuestion studentExamQuestion, CancellationToken cancellationToken = default)
    {
        await context.StudentExamQuestions.AddAsync(studentExamQuestion, cancellationToken);
    }

    public async Task<bool> IsTheQuestionAlreadyAnswer(int examQuestionId, Guid userId, CancellationToken cancellationToken = default)
    {
        return await context.StudentExamQuestions.AnyAsync(p => p.ExamQuestionId == examQuestionId && p.StudentId == userId, cancellationToken);
    }
}
