using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace pba_api.Models.EstimateSheetRiskProfileModel
{
    public class EstimateSheetRiskProfileEntityTypeConfiguration : IEntityTypeConfiguration<EstimateSheetRiskProfile>
    {
        public void Configure(EntityTypeBuilder<EstimateSheetRiskProfile> builder)
        {
            builder
                .UseCollation("utf8mb4_danish_ci")
                .HasCharSet("utf8mb4");

            builder
                .HasKey(x => new { x.RiskProfileId, x.EstimateSheetId });

            #region EntityRelations
            builder
                .HasOne(r => r.RiskProfile)
                .WithMany(x => x.EstimateSheetRiskProfiles)
                .HasForeignKey(r => r.RiskProfileId);

            builder
                .HasOne(e => e.EstimateSheet)
                .WithMany(x => x.EstimateSheetRiskProfiles)
                .HasForeignKey(e => e.RiskProfileId);
            #endregion
        }
    }
}
