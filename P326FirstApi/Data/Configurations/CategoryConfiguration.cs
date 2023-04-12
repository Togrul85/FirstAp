using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P326FirstApi.Models;

namespace P326FirstApi.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.Name).HasMaxLength(50).IsRequired(true);
            builder.Property(c => c.Desc).HasMaxLength(300).IsRequired(false);
            builder.Property(c => c.CreatedDate).HasDefaultValueSql("GetUtcDate()");
            builder.Property(c => c.UpdateDate).HasDefaultValueSql("GetUtcDate()");
        }
    }
}
