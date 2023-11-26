using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantServer.Domain.Tables;


namespace RestaurantServer.Infrastructure.Configurations;
internal sealed class TableConfiguration : IEntityTypeConfiguration<Table>
{
    public void Configure(EntityTypeBuilder<Table> builder)
    {
        builder.ToTable("Tables");
        builder.Property(p => p.Amount)
            .HasConversion(money => money.Value, value => new(value))
            .HasColumnType("money");
    }
}
