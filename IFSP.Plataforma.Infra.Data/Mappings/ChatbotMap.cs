using IFSP.Plataforma.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IFSP.Plataforma.Infra.Data.Mappings
{
    public class ChatbotMap : IEntityTypeConfiguration<Chatbot>
    {
        public void Configure(EntityTypeBuilder<Chatbot> builder)
        {
            builder.Property(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(200);

            builder.Property(x => x.DiscordExported)
                .HasDefaultValue(false);

            builder.Property(x => x.MessengerExported)
                .HasDefaultValue(false);
        }
    }
}
