using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityLibraryApp.Models;

public sealed class AppUser : IdentityUser<Guid>
{
    [NotMapped]
    public override bool TwoFactorEnabled { get; set; }

    [NotMapped]
    public override bool PhoneNumberConfirmed { get; set; }

    [NotMapped]
    public override string? ConcurrencyStamp { get; set; }
}


public class A : Identity<string>
{
    [NotMapped]
    public override string PhoneNumber { get; set; }
}

public class Identity<T>
{
    public T Id { get; set; }
    public string UserName { get; set; }
    public virtual string PhoneNumber { get; set; }
}
