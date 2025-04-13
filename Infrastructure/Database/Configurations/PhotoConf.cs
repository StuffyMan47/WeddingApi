using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Database.Tables.Photo;

namespace Infrastructure.Database.Configurations;

public class PhotoConf : IEntityTypeConfiguration<Photo>
{
    public void Configure(EntityTypeBuilder<Photo> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Event).WithMany().HasForeignKey(x=>x.EventId);
    }
}
