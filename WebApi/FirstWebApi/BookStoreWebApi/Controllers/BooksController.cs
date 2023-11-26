using BookStoreWebApi.Context;
using BookStoreWebApi.Dtos;
using BookStoreWebApi.Exceptions;
using BookStoreWebApi.Models;
using BookStoreWebApi.Options;
using BookStoreWebApi.ValueObjects;
using EntityFrameworkCorePagination.Nuget.Pagination;

using GenericFileService.Files;
using GSF.FuzzyStrings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using static System.Reflection.Metadata.BlobBuilder;

namespace BookStoreWebApi.Controllers;

public class BooksController : ApiController
{
    private readonly AppDbContext _context;

    public BooksController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] CreateBookDto request, CancellationToken cancellationToken)
    {
        string fileName = FileService.FileSaveToServer(request.Image, "C:/Users/taner/source/repos/CareerHuBT-WebApi/MyBookStoreClient/src/assets/img/");
        var book = new Book
        {
            Name = request.Name,
            DailyPrice = request.DailyPrice,
            Summary = request.Summary,
            Author = request.Author,
            PublishDate = request.PublishDate,
            ImageUrl = fileName,
            Quantity = request.Quantity
        };
        await _context.Books.AddAsync(book, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return NoContent(); //204
    }

    [HttpPost]
    public async Task<IActionResult> CreateRamdonBooks([FromForm] CreateBookDto request, CancellationToken cancellationToken)
    {
        string fileName = FileService.FileSaveToServer(request.Image, "C:/Users/taner/source/repos/CareerHuBT-WebApi/MyBookStoreClient/src/assets/img/");

        List<Book> books = new();

        for (int i = 0; i < 500000; i++)
        {
            var dailyPrice = new Money(request.DailyPrice.Amount, request.DailyPrice.Currency);
            var book = new Book
            {
                Name = request.Name,
                DailyPrice = dailyPrice,
                Summary = request.Summary,
                Author = request.Author,
                PublishDate = request.PublishDate,
                ImageUrl = fileName,
                Quantity = request.Quantity
            };
            books.Add(book);
        }
        
        await _context.Books.AddRangeAsync(books, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return NoContent(); //204
    }

    [HttpPost]
    public async Task<IActionResult> GetAllForAdminUI(RequestDto request, CancellationToken cancellationToken)
    {
        var response =
            await _context.Books
            .Where(p => p.Name.ToLower().Contains(request.Search.ToLower()))
            .Where(p => p.IsDeleted == false)
            .ToPagedListAsync(request.PageNumber, request.PageSize, cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> GetAllForUserUI(RequestDto request, CancellationToken cancellationToken)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();

        var books = new List<Book>();
        if (string.IsNullOrEmpty(request.Search))
        {
            books = _context.Books.Take(request.PageSize).ToList();
        }
        else
        {
            //books = 
            //    _context.Books
            //    .Where(p=> p.Name.ToLower().Contains(request.Search.ToLower()))
            //    .Take(request.PageSize).ToList();

            books =
                 _context.Books.FromSqlRaw($"select * from Books where Name like '%{request.Search.ToLower()}%'")
                 .Take(request.PageSize)
                 .AsNoTracking()
                 .ToList();

            //books =
            //_context.Books
            //.ToList()
            //.Where(p => p.Name.ApproximatelyEquals(request.Search, FuzzyStringComparisonOptions.UseLongestCommonSubsequence, FuzzyStringComparisonTolerance.Strong))
            //.Take(request.PageSize)
            //.ToList();
        }

        stopwatch.Stop();

        var second = (int)stopwatch.Elapsed.TotalSeconds;
        var milsecond = (int)stopwatch.Elapsed.TotalMilliseconds;

        return Ok(books);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> RemoveById(string id, CancellationToken cancellationToken)
    {
        var book = await _context.Books.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        if (book is null)
            throw new NotFoundBookException();
        book.IsDeleted = true;
        await _context.SaveChangesAsync(cancellationToken);
        return NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> Update([FromForm] UpdateBookDto request, CancellationToken cancellationToken)
    {
        var book = await _context.Books.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
        if (book is null)
            throw new NotFoundBookException();

        if (request.Image is not null)
        {
            book.ImageUrl = FileService.FileSaveToServer(request.Image, "wwwroot/images/");
        }

        book.Name = request.Name;
        book.DailyPrice = request.DailyPrice;
        book.Summary = request.Summary;
        book.Author = request.Author;
        book.PublishDate = request.PublishDate;
        book.Quantity = request.Quantity;
        book.IsActive = request.IsActive;
        await _context.SaveChangesAsync(cancellationToken);
        return NoContent();
    }
}