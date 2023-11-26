using LiveSupportServer.Domain.ChatRooms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LiveSupportServer.Infrastructure.Configuration;

internal sealed class ChatRoomConfiguration : IEntityTypeConfiguration<ChatRoom>
{
    public void Configure(EntityTypeBuilder<ChatRoom> builder)
    {
        builder.ToTable("ChatRooms");
        builder
            .Property(p => p.ClientNameLastname)
            .HasConversion(client => client.Value, value => new(value));

        builder
            .Property(p => p.UserId)
            .IsRequired(false);

        builder
            .Property(p => p.Subject)
            .HasConversion(subject => subject.Value, value => new(value));

        builder
            .Property(p => p.WhoIsTheLastAnswer)
            .HasConversion(who => who.Value, value => new(value));

        builder
            .HasMany(p => p.ChatRoomDetails)
            .WithOne()
            .HasForeignKey(p => p.ChatRoomId);
    }
}