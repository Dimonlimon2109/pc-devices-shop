using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PCDevicesShop.DAL.Entities;

namespace PCDevicesShop.DAL.Data.SeedConfigurations
{
    public class DeviceSeedConfiguration : IEntityTypeConfiguration<Device>
    {
        public void Configure(EntityTypeBuilder<Device> builder)
        {
            builder.HasData(
                // Мыши (3 шт)
                new Device
                {
                    Id = Guid.NewGuid(),
                    Name = "Logitech G102",
                    Category = DeviceCategories.Mouse,
                    Description = "Удобная игровая мышь для легких побед в Dota 2",
                    Price = 120.25,
                    StockQuantity = 15,
                    ImagePath = "/images/g102.png"
                },
                new Device
                {
                    Id = Guid.NewGuid(),
                    Name = "Razer DeathAdder V2",
                    Category = DeviceCategories.Mouse,
                    Description = "Эргономичная игровая мышь с оптическим сенсором 20000 DPI",
                    Price = 249.99,
                    StockQuantity = 8,
                    ImagePath = "/images/razer_mouse.png"
                },
                new Device
                {
                    Id = Guid.NewGuid(),
                    Name = "SteelSeries Rival 3",
                    Category = DeviceCategories.Mouse,
                    Description = "Легкая игровая мышь с RGB-подсветкой",
                    Price = 179.50,
                    StockQuantity = 12,
                    ImagePath = "/images/rival3.png"
                },

                // Мониторы (5 шт)
                new Device
                {
                    Id = Guid.NewGuid(),
                    Name = "Samsung Odyssey OLED G6",
                    Category = DeviceCategories.Monitor,
                    Description = "27\", 2560x1440, OLED, 240 Гц, AMD FreeSync/NVIDIA G-Sync",
                    Price = 2899.00,
                    StockQuantity = 5,
                    ImagePath = "/images/monitor.png"
                },
                new Device
                {
                    Id = Guid.NewGuid(),
                    Name = "LG UltraGear 27GN800-B",
                    Category = DeviceCategories.Monitor,
                    Description = "27\" IPS, 2560x1440, 144Hz, 1ms, HDR10",
                    Price = 1599.00,
                    StockQuantity = 7,
                    ImagePath = "/images/lg_monitor.png"
                },
                new Device
                {
                    Id = Guid.NewGuid(),
                    Name = "ASUS TUF Gaming VG259QM",
                    Category = DeviceCategories.Monitor,
                    Description = "24.5\" Full HD, 280Hz, 1ms, ELMB Sync",
                    Price = 1299.00,
                    StockQuantity = 10,
                    ImagePath = "/images/asus_monitor.png"
                },
                new Device
                {
                    Id = Guid.NewGuid(),
                    Name = "Dell S2721DGF",
                    Category = DeviceCategories.Monitor,
                    Description = "27\" QHD, 165Hz, 1ms, NVIDIA G-Sync Compatible",
                    Price = 2199.00,
                    StockQuantity = 4,
                    ImagePath = "/images/dell_monitor.png"
                },
                new Device
                {
                    Id = Guid.NewGuid(),
                    Name = "AOC 24G2U",
                    Category = DeviceCategories.Monitor,
                    Description = "23.8\" IPS, 144Hz, 1ms, AMD FreeSync",
                    Price = 899.00,
                    StockQuantity = 15,
                    ImagePath = "/images/aoc_monitor.png"
                },

                // Клавиатуры (7 шт)
                new Device
                {
                    Id = Guid.NewGuid(),
                    Name = "Razer BlackWidow V3",
                    Category = DeviceCategories.Keyboard,
                    Description = "Механическая игровая клавиатура с переключателями Razer Green",
                    Price = 349.99,
                    StockQuantity = 6,
                    ImagePath = "/images/razer_kb.png"
                },
                new Device
                {
                    Id = Guid.NewGuid(),
                    Name = "Logitech G Pro X",
                    Category = DeviceCategories.Keyboard,
                    Description = "Механическая клавиатура с заменяемыми переключателями",
                    Price = 399.00,
                    StockQuantity = 3,
                    ImagePath = "/images/logitech_kb.png"
                },
                new Device
                {
                    Id = Guid.NewGuid(),
                    Name = "SteelSeries Apex Pro",
                    Category = DeviceCategories.Keyboard,
                    Description = "Клавиатура с регулируемым ходом переключателей OmniPoint",
                    Price = 459.99,
                    StockQuantity = 2,
                    ImagePath = "/images/steelseries_kb.png"
                },
                new Device
                {
                    Id = Guid.NewGuid(),
                    Name = "HyperX Alloy Origins Core",
                    Category = DeviceCategories.Keyboard,
                    Description = "Компактная механическая клавиатура с переключателями HyperX Red",
                    Price = 279.00,
                    StockQuantity = 9,
                    ImagePath = "/images/hyperx_kb.png"
                },
                new Device
                {
                    Id = Guid.NewGuid(),
                    Name = "Corsair K70 RGB MK.2",
                    Category = DeviceCategories.Keyboard,
                    Description = "Механическая клавиатура с алюминиевой рамкой и RGB-подсветкой",
                    Price = 379.00,
                    StockQuantity = 5,
                    ImagePath = "/images/corsair_kb.png"
                },
                new Device
                {
                    Id = Guid.NewGuid(),
                    Name = "Keychron K8",
                    Category = DeviceCategories.Keyboard,
                    Description = "Беспроводная механическая клавиатура с поддержкой Bluetooth",
                    Price = 299.00,
                    StockQuantity = 12,
                    ImagePath = "/images/keychron_kb.png"
                },
                new Device
                {
                    Id = Guid.NewGuid(),
                    Name = "Ducky One 3",
                    Category = DeviceCategories.Keyboard,
                    Description = "Механическая клавиатура с PBT кейкапами и переключателями Cherry MX",
                    Price = 329.00,
                    StockQuantity = 7,
                    ImagePath = "/images/ducky_kb.png"
                }
            );
        }
    }
}