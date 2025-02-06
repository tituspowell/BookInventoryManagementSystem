using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookInventoryManagementSystem.Data.Configurations;

public class IdentityUserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
    {
        builder.HasData(
            new IdentityUserRole<string>
            {
                RoleId = "c023adca-74a5-44a3-b2cb-0759c296c7ec",
                UserId = "d6e40b98-aec1-4434-b987-d65f340536f4",
            },
            new IdentityUserRole<string>
            {
                RoleId = "233e1017-9c65-4690-bf48-546434d3b93e",
                UserId = "librarianid",
            },
            new IdentityUserRole<string>
            {
                RoleId = "3db65512-a1a9-4087-986f-a2e9360b2f47",
                UserId = "readerid",
            }
            );
    }
}
