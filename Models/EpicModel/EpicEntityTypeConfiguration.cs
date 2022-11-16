using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace pba_api.Models.EpicModel
{
    public class EpicEntityTypeConfiguration : IEntityTypeConfiguration<Epic>
    {
        public void Configure(EntityTypeBuilder<Epic> builder)
        {
            builder
                .UseCollation("utf8mb4_danish_ci")
                .HasCharSet("utf8mb4");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.EpicName)
                .HasColumnType("varchar")
                .HasMaxLength(50);

            builder
                .HasOne(x => x.EpicStatus)
                .WithMany(e => e.Epics)
                .HasForeignKey(x => x.EpicStatusId)
                .IsRequired();
        }
    }
}
