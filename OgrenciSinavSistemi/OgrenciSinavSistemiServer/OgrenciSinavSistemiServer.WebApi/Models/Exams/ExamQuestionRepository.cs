using Microsoft.EntityFrameworkCore;
using OgrenciSinavSistemiServer.WebApi.Context;

namespace OgrenciSinavSistemiServer.WebApi.Models.Exams;

public sealed class ExamQuestionRepository(ApplicationDbContext context) : IExamQuestionRepository
{
    public async Task<List<ExamQuestion>> GetExamQuestionsByExamIdAsync(Guid examId, CancellationToken cancellationToken = default)
    {
        return await context.ExamQuestions.Where(p => p.ExamId == examId).ToListAsync(cancellationToken);
    }
}
