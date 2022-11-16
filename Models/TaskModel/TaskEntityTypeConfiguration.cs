using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace pba_api.Models.TaskModel
{
    public class TaskEntityTypeConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder
                .UseCollation("utf8mb4_danish_ci")
                .HasCharSet("utf8mb4");

            builder
                .HasKey(x => x.Id);

            #region EntityRelations
            builder
                .HasOne(x => x.Role)
                .WithMany(r => r.Tasks)
                .HasForeignKey(x => x.RoleId)
                .IsRequired();

            builder
                .HasOne(x => x.RiskProfile)
                .WithMany(r => r.Tasks)
                .HasForeignKey(x => x.RiskProfileId)
                .IsRequired();
            #endregion

            #region PropertyConfigurations
            builder
                .Property(x => x.ParentId)
                .HasColumnType("int");

            builder
                .Property(x => x.HourEstimate)
                .HasColumnType("float")
                .IsRequired();

            builder
                .Property(x => x.EstimateReasoning)
                .HasColumnType("varchar")
                .HasMaxLength(2400)
                .IsRequired();

            builder
                .Property(x => x.OptOut)
                .HasColumnType("bit");

            builder
                .Property(x => x.TaskDescription)
                .HasColumnType("varchar")
                .HasMaxLength(2400)
                .IsRequired();
            #endregion
        }
    }
}
