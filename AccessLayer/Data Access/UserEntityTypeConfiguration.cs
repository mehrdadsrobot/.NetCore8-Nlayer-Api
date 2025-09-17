using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Claims;
using Models.UserModels;

namespace Data_Access
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.Property(x => x.Email).IsRequired();
            builder.HasMany(r => r.Roles).WithMany().UsingEntity(j => j.ToTable("UserRole"));
            builder.HasKey(u=>u.Id);
        }
    }
}
