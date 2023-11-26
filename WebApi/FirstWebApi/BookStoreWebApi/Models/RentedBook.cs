using BookStoreWebApi.Models.Abstractions;
using BookStoreWebApi.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreWebApi.Models;

public sealed class RentedBook : Entity
{
    public DateTime RentedDate { get; set; }
    public DateTime DeliveryDate { get; set; }
    public Money Payment { get; set; }
    public CreditCard CreditCard { get; set; }
    public Address Address { get; set; }

    public string BookId { get; set; }
    public Book Book { get; set; }

    [ForeignKey("AppUser")]
    public string UserId { get; set; }

    public AppUser AppUser { get; set; }
}