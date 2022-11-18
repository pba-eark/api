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
                .HasOne(x => x.RiskProfile)
                .WithMany(e => e.EstimateSheetRiskProfiles)
                .HasForeignKey(x => x.RiskProfileId);
            #endregion
        }
    }
}
