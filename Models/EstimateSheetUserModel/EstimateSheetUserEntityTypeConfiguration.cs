using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace pba_api.Models.EstimateSheetUserModel
{
    public class EstimateSheetUserEntityTypeConfiguration : IEntityTypeConfiguration<EstimateSheetUser>
    {
        public void Configure(EntityTypeBuilder<EstimateSheetUser> builder)
        {
            builder
                .UseCollation("utf8mb4_danish_ci")
                .HasCharSet("utf8mb4");

            builder
                .HasKey(x => new { x.EstimateSheetId, x.UserId });

            #region EntityRelation
            builder
                .HasOne(x => x.EstimateSheet)
                .WithMany(e => e.EstimateSheetUsers)
                .HasForeignKey(x => x.EstimateSheetId);

            builder
                .HasOne(x => x.User)
                .WithMany(u => u.EstimateSheetUsers)
                .HasForeignKey(x => x.UserId);
            #endregion
        }
    }
}
