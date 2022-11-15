using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace pba_api.Models.EstimateSheetModel
{
    public class EstimateSheetEntityTypeConfiguration : IEntityTypeConfiguration<EstimateSheet>
    {
        public void Configure(EntityTypeBuilder<EstimateSheet> builder)
        {
            builder
                .HasKey(x => x.Id);

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
                .HasMaxLength(250);

            builder
                .Property(x => x.JiraLink)
                .HasColumnType("varchar")
                .HasMaxLength(250);

            builder
                .Property(x => x.WireframeLink)
                .HasColumnType("varchar")
                .HasMaxLength(250);
            #endregion
        }
    }
}
