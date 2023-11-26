using LiveSupportServer.Domain.ChatDetails;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LiveSupportServer.Infrastructure.Configuration;

internal sealed class ChatRoomDetailConfiguration : IEntityTypeConfiguration<ChatRoomDetail>
{
    public void Configure(EntityTypeBuilder<ChatRoomDetail> builder)
    {
        builder.ToTable("ChatRoomDetails");
    }
}