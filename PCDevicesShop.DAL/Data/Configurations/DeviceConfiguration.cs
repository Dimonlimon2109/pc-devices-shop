using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PCDevicesShop.DAL.Entities;

namespace PCDevicesShop.DAL.Data.Configurations
{
    public class DeviceConfiguration : IEntityTypeConfiguration<Device>
    {
        public void Configure(EntityTypeBuilder<Device> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(d => d.Description)
                .IsRequired()
                .HasMaxLength(256);
            builder.Property(d => d.Price)
                .IsRequired();
            builder.Property(d => d.StockQuantity)
                .HasDefaultValue(0);
            builder.Property(d => d.Category)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(d => d.ImagePath)
                .HasDefaultValue("/images/default.png");
        }
    }
}
