using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P326FirstApi.Models;

namespace P326FirstApi.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
         builder.Property(p=>p.Name).HasMaxLength(50).IsRequired(true);
            builder.Property(p=>p.SalePrice).IsRequired(true);
            builder.Property(p=>p.CreatedDate).HasDefaultValueSql("GetUtcDate()");
            builder.Property(p => p.UpdateDate).HasDefaultValue(DateTime.UtcNow);


        }
    }

}
