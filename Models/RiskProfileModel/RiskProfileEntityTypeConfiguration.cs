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
                .HasColumnType("bit")
                .IsRequired();

            builder
                .Property(x => x.ProfileName)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(x => x.Percentage)
                .HasColumnType("int")
                .IsRequired();

            #region
            builder
                .HasMany(e => e.EstimateSheetRiskProfiles)
                .WithOne(x => x.RiskProfile)
                .HasForeignKey(e => new { e.RiskProfileId, e.EstimateSheetId });

            builder
                .HasMany(t => t.Tasks)
                .WithOne(x => x.RiskProfile)
                .HasForeignKey(t => t.Id);
            #endregion
        }
    }
}
