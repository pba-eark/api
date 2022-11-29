using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace pba_api.Models.EpicStatusModel
{
    public class EpicStatusEntityTypeConfiguration : IEntityTypeConfiguration<EpicStatus>
    {
        public void Configure(EntityTypeBuilder<EpicStatus> builder)
        {
            builder
                .UseCollation("utf8mb4_danish_ci")
                .HasCharSet("utf8mb4");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.EpicStatusName)
                .HasColumnType("varchar")
                .HasMaxLength(50);

            builder
                .Property(x => x.Default)
                .HasColumnType("bit");
        }
    }
}
