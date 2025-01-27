using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookInventoryManagementSystem.Data.Configurations;

public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        var hasher = new PasswordHasher<ApplicationUser>();

        builder.HasData(
            new ApplicationUser
            {
                Id = "d6e40b98-aec1-4434-b987-d65f340536f4",
                Email = "admin@localhost.com",
                NormalizedEmail = "ADMIN@LOCALHOST.COM",
                UserName = "admin@localhost.com",
                NormalizedUserName = "ADMIN@LOCALHOST.COM",
                //PasswordHash = "AQAAAAIAAYagAAAAEAjIpFqaJLTYjRFYEFXVjXNcUhVxGPxTXHo9Iq0Ck+OJXkUvMvYfIxKrRGDCmBBM3g==", // Pre-computed hash for "P@ssword1"
                PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                EmailConfirmed = true,
                ConcurrencyStamp = "stamp-admin-user", // Adding a static value
                SecurityStamp = "SECURITYSTAMP", // Adding a static value
                FirstName = "Default",
                LastName = "Admin",
            }
            );
    }
}
