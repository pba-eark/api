using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pba_api.Models.EstimateSheetModel;

namespace pba_api.Models.SheetStatusModel
{
    public class SheetStatusEntityTypeConfiguration : IEntityTypeConfiguration<SheetStatus>
    {
        public void Configure(EntityTypeBuilder<SheetStatus> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.SheetStausName)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
