using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace pba_api.Models.EstimateSheetModel
{
    public class EstimateSheetEntityTypeConfiguration : IEntityTypeConfiguration<EstimateSheet>
    {
        public void Configure(EntityTypeBuilder<EstimateSheet> builder)
        {
            builder
                .UseCollation("utf8mb4_danish_ci")
                .HasCharSet("utf8mb4");

            builder
                .HasKey(x => x.Id);

            //builder.Property(x => x.Id).ValueGeneratedOnAdd().UseMySqlIdentityColumn();

            #region EntityRelations
            builder
                .HasOne(x => x.User)
                .WithMany(u => u.EstimateSheets)
                .HasForeignKey(x => x.UserId);

            builder
                .HasOne(x => x.Customer)
                .WithMany(c => c.EstimateSheets)
                .HasForeignKey(x => x.CustomerId);

            builder
                .HasOne(x => x.SheetStatus)
                .WithMany(s => s.EstimateSheets)
                .HasForeignKey(x => x.SheetStatusId);

            builder
                .HasMany(a => a.AdditionalExpenses)
                .WithOne(x => x.EstimateSheet)
                .HasForeignKey(a => a.Id);

            builder
                .HasMany(e => e.Epics)
                .WithOne(x => x.EstimateSheet)
                .HasForeignKey(e => e.Id);

            builder
                .HasMany(t => t.Tasks)
                .WithOne(x => x.EstimateSheet)
                .HasForeignKey(t => t.Id);

            //builder
            //    .HasMany(e => e.EstimateSheetRiskProfiles)
            //    .WithOne(x => x.EstimateSheet)
            //    .HasForeignKey(e => new { e.RiskProfileId, e.EstimateSheetId });
            #endregion

            #region PropertyConfigurations
            builder
                .Property(x => x.SheetName)
                .HasColumnType("varchar")
                .HasMaxLength(250)
                .IsRequired();

            builder
                .Property(x => x.JiraBoardId)
                .HasColumnType("int")
                .IsRequired();

            builder
                .Property(x => x.WorkbookLink)
                .HasColumnType("varchar")
                .HasMaxLength(250)
                .IsRequired(false);

            builder
                .Property(x => x.JiraLink)
                .HasColumnType("varchar")
                .HasMaxLength(250)
                .IsRequired(false);

            builder
                .Property(x => x.WireframeLink)
                .HasColumnType("varchar")
                .HasMaxLength(250)
                .IsRequired(false);

            // NavigationProperties
            //builder
            //    .Property(x => x.UserId)
            //    .HasColumnType("int")
            //    .IsRequired();

            //builder
            //    .Property(x => x.CustomerId)
            //    .HasColumnType("int");
            //    //.IsRequired(false);

            //builder
            //    .Property(x => x.SheetStatusId)
            //    .HasColumnType("int");
            //    //.IsRequired(false);
            #endregion
        }
    }
}
