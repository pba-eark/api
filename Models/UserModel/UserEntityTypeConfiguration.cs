using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace pba_api.Models.UserModel
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.FirstName)
                .HasColumnType("varchar")
                .HasMaxLength(500)
                .IsRequired();

            builder
                .Property(x => x.LastName)
                .HasColumnType("varchar")
                .HasMaxLength(500)
                .IsRequired();

            builder
                .Property(x => x.Email)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(x => x.Password)
                .HasColumnType("varchar")
                .HasMaxLength(2400)
                .IsRequired();
        }
    }
}
