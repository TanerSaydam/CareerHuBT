using LiveSupportServer.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LiveSupportServer.Infrastructure.Configuration;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder
            .Property(p => p.Name)
           .HasConversion(name => name.Value, value => new(value));

        builder
           .Property(p => p.UserName)
           .HasConversion(userName => userName.Value, value => new(value));
    }
}