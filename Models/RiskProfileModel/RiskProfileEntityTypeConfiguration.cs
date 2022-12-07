using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace pba_api.Models.RiskProfileModel
{
    public class RiskProfileEntityTypeConfiguration : IEntityTypeConfiguration<RiskProfile>
    {
        public void Configure(EntityTypeBuilder<RiskProfile> builder)
        {
            builder
                .UseCollation("utf8mb4_danish_ci")
                .HasCharSet("utf8mb4");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Global)
                .HasColumnType("bit");

            builder
                .Property(x => x.Default)
                .HasColumnType("bit");

            builder
                .Property(x => x.ProfileName)
                .HasColumnType("varchar")
                .HasMaxLength(50);

            builder
                .Property(x => x.Percentage)
                .HasColumnType("int");
        }
    }
}
