using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.UserModels;

namespace Data_Access
{
    public class UserInfoEntityTypeConfiguration : IEntityTypeConfiguration<UserInfo>
    {
        public void Configure(EntityTypeBuilder<UserInfo> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(ui => ui.User).WithOne(u => u.UserInfo).HasForeignKey<UserInfo>(u => u.UserId);
        }
    }
}
