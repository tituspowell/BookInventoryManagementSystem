using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookInventoryManagementSystem.Data.Configurations;

public class IdentityRoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(
            new IdentityRole
            {
                Id = "3db65512-a1a9-4087-986f-a2e9360b2f47",
                Name = "Reader",
                NormalizedName = "READER",
                ConcurrencyStamp = "stamp-reader" // Add a static value
            },
            new IdentityRole
            {
                Id = "233e1017-9c65-4690-bf48-546434d3b93e",
                Name = "Librarian",
                NormalizedName = "LIBRARIAN",
                ConcurrencyStamp = "stamp-librarian" // Add a static value
            },
            new IdentityRole
            {
                Id = "c023adca-74a5-44a3-b2cb-0759c296c7ec",
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR",
                ConcurrencyStamp = "stamp-administrator" // Add a static value
            }
            );
    }
}
