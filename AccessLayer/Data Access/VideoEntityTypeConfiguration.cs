using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Data_Access
{
    public class VideoEntityTypeConfiguration : IEntityTypeConfiguration<Videos>
    {
        public void Configure(EntityTypeBuilder<Videos> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(v => v.Categories).WithMany(x => x.Videos)
                .UsingEntity(j => j.ToTable("VideoCategory"));

            builder.HasOne(v => v.User).WithMany().HasForeignKey(x => x.User_Id);
        }
    }
}
