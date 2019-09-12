using IFSP.Plataforma.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IFSP.Plataforma.Infra.Data.Mappings
{
    public class DialogueMap : IEntityTypeConfiguration<Dialogue>
    {
        public void Configure(EntityTypeBuilder<Dialogue> builder)
        {
            builder.Property(x => x.Id);

            builder.Property(x => x.UserInput)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.ChatbotOutput)
                .HasMaxLength(50);

        }
    }
}
