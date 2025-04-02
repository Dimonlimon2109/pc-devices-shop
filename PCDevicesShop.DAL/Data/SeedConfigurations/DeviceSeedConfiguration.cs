using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PCDevicesShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCDevicesShop.DAL.Data.SeedConfigurations
{
    public class DeviceSeedConfiguration : IEntityTypeConfiguration<Device>
    {
        public void Configure(EntityTypeBuilder<Device> builder)
        {
            builder.HasData(
                new Device
                {
                    Id = Guid.NewGuid(),
                    Name = "Logitech G102",
                    Category = DeviceCategories.Mouse,
                    Description = "Удобная игровая мышь для легких побед в Dota 2",
                    Price = 120.25,
                    ImagePath = "/images/g102.png"
                },
                new Device
                {
                    Id = Guid.NewGuid(),
                    Name = "Игровой монитор Samsung Odyssey OLED G6 LS27DG612SIXCI",
                    Category = DeviceCategories.Monitor,
                    Description = "27\", 16:9, 2560x1440, OLED, подсветка с квантовыми точками, 240 Гц, AMD FreeSync Premium Pro/совместимый с NVIDIA G-Sync, интерфейсы HDMI+DisplayPort, регулировка высоты, портретный режим",
                    Price = 2899.00,
                    ImagePath = "/images/monitor.png"
                }
                );

        }
    }
}
