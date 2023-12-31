﻿using Microsoft.EntityFrameworkCore;
using OgrenciSinavSistemiServer.WebApi.Abstractions;
using OgrenciSinavSistemiServer.WebApi.Models.Exams;
using OgrenciSinavSistemiServer.WebApi.Models.StudentExamQuestions;
using OgrenciSinavSistemiServer.WebApi.Models.UserExams;
using OgrenciSinavSistemiServer.WebApi.Models.Users;

namespace OgrenciSinavSistemiServer.WebApi.Context;

public sealed class ApplicationDbContext : DbContext, IUnitOfWork
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Exam> Exams { get; set; }
    public DbSet<ExamQuestion> ExamQuestions { get; set; }
    public DbSet<StudentExam> StudentExams { get; set; }
    public DbSet<StudentExamQuestion> StudentExamQuestions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudentExam>().HasKey(x => new { x.UserId, x.ExamId });
    }
}
