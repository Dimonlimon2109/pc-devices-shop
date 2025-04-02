using Microsoft.EntityFrameworkCore;
using PCDevicesShop.DAL.Data.Configurations;
using PCDevicesShop.DAL.Data.SeedConfigurations;
using PCDevicesShop.DAL.Entities;

namespace PCDevicesShop.DAL.Data
{
    public class ApplicationContext:DbContext
    {

        public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options) {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Device> Devices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new DeviceConfiguration());

            modelBuilder.ApplyConfiguration(new UserSeedConfiguration());
            modelBuilder.ApplyConfiguration(new DeviceSeedConfiguration());
        }

    }
}
