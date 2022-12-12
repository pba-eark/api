using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace pba_api.Models.EstimateSheetRoleModel
{
    public class EstimateSheetRoleEntityTypeConfiguration : IEntityTypeConfiguration<EstimateSheetRole>
    {
        public void Configure(EntityTypeBuilder<EstimateSheetRole> builder)
        {
            builder
                .UseCollation("utf8mb4_danish_ci")
                .HasCharSet("utf8mb4");

            builder
                .HasKey(x => new { x.EstimateSheetId, x.RoleId });

            #region EntityRelations
            builder
                .HasOne(x => x.EstimateSheet)
                .WithMany(e => e.EstimateSheetRoles)
                .HasForeignKey(x => x.EstimateSheetId);

            builder
                .HasOne(x => x.Role)
                .WithMany(r => r.EstimateSheetRoles)
                .HasForeignKey(x => x.RoleId);
            #endregion
        }
    }
}
