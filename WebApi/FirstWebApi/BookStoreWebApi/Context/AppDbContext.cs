using BookStoreWebApi.Models;
using BookStoreWebApi.ValueObjects;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Exception = BookStoreWebApi.Models.Exception;

namespace BookStoreWebApi.Context;

public sealed class AppDbContext : IdentityDbContext<AppUser, IdentityRole, string>
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<RentedBook> RentedBooks { get; set; }
    public DbSet<Exception> Exceptions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>().Property(p => p.Id).ValueGeneratedNever();
        modelBuilder.Entity<RentedBook>().Property(p => p.Id).ValueGeneratedNever();
        modelBuilder.Entity<RentedBook>().Property(p => p.DeliveryDate).HasColumnType("date");
        modelBuilder.Entity<RentedBook>().Property(p => p.RentedDate).HasColumnType("date");
        modelBuilder.Entity<Book>().OwnsOne<Money>(p => p.DailyPrice, param=>
        {
            param.Property(s => s.Amount).HasColumnType("money");
        });
        modelBuilder.Entity<RentedBook>().OwnsOne<Money>(p => p.Payment, param =>
        {
            param.Property(s => s.Amount).HasColumnType("money");
        });
        modelBuilder.Entity<RentedBook>().OwnsOne<Address>(p => p.Address);
        modelBuilder.Entity<RentedBook>().OwnsOne<CreditCard>(p => p.CreditCard);

        modelBuilder.Ignore<IdentityUserLogin<string>>();
        modelBuilder.Ignore<IdentityUserRole<string>>();
        modelBuilder.Ignore<IdentityUserClaim<string>>();
        modelBuilder.Ignore<IdentityUserToken<string>>();
        modelBuilder.Ignore<IdentityRoleClaim<string>>();
        modelBuilder.Ignore<IdentityRole<string>>();

        modelBuilder.Entity<RentedBook>().HasOne(p => p.Book).WithMany().HasForeignKey(p => p.BookId);
        //bire çok ilişki örneği
    }
}