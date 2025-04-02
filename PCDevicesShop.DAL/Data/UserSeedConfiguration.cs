using Microsoft.EntityFrameworkCore;
using PCDevicesShop.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace PCDevicesShop.DAL.Data
{
    public class UserSeedConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User
                {
                    Id = Guid.NewGuid(),
                    UserName = "admin",
                    Email = "admin@example.com",
                    Role = "Admin",
                    PasswordHash = "$2a$11$KtBL0bBoDeJF1CTESe5LKeEhNlzEr7sSwuoYTsQUb2Uy1Bph/jiVy"
                });

        }
    }
}
