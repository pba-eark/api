using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pba_api.Models.CustomerModel;
using System.Text;

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
                .HasMany(x => x.AdditionalExpenses)
                .WithOne(a => a.EstimateSheet)
                .HasForeignKey(a => a.Id);

            builder
                .HasMany(x => x.Epics)
                .WithOne(e => e.EstimateSheet)
                .HasForeignKey(e => e.Id);

            builder
                .HasMany(x => x.Tasks)
                .WithOne(t => t.EstimateSheet)
                .HasForeignKey(t => t.Id);
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
