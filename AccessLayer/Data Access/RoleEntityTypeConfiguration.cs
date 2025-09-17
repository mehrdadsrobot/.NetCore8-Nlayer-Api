using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Claims;

namespace Data_Access
{
    public class RoleEntityTypeConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(a => a.UserActions).WithMany(r => r.Roles)
                .UsingEntity(j => j.ToTable("RoleAction"));
        }
    }
}
