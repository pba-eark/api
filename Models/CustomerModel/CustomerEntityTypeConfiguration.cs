using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace pba_api.Models.CustomerModel
{
    public class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
                .UseCollation("utf8mb4_danish_ci")
                .HasCharSet("utf8mb4");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.CustomerName)
                .HasColumnType("varchar")
                .HasMaxLength(250)
                .IsRequired();

            //#region EntityRelations
            //builder
            //    .HasMany(e => e.EstimateSheets)
            //    .WithOne(x => x.Customer)
            //    .HasForeignKey(e => e.Id);
            //#endregion
        }
    }
}
