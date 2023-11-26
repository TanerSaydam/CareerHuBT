using BookStoreWebApi.Models.Abstractions;
using BookStoreWebApi.ValueObjects;

namespace BookStoreWebApi.Models;

public sealed class Book : Entity
{
    public string Name { get; set; }
    public Money DailyPrice { get; set; }
    public string Summary { get; set; }
    public string Author { get; set; }
    public DateTime PublishDate { get; set; }
    public string ImageUrl { get; set; }
    public int Quantity { get; set; } //10
    public bool IsActive { get; set; } = true;
    public bool IsDeleted { get; set; } = false;
}