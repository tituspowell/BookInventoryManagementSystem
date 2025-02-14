using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BookInventoryManagementSystem.Data;

// The ApplicationDBContext class inheriting from IdentityDBContext<ApplicationUser> and overriding OnModelCreating
// is a common pattern in ASP.NET Core applications using Entity Framework Core(EF Core) with Identity.
// It's not the only way to structure an EF Core application, but it is a well-established and effective pattern
// when you care about Identity.
// The OnModelCreating method is used to seed the database with initial values.
public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // To create new data classes, you can add a property below and then right-click on the class name and select "Quick Actions and Refactorings" -> "Generate class"
    public DbSet<Book> Books { get; set; }
    public DbSet<Review> Reviews { get; set; }


    // Overriding this method is how you seed the database with initial values
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Cascade delete all reviews automatically if the associated book is deleted
        // Probably unnecessary because that constraint was already set in the Review table in the database
        builder.Entity<Review>()
            .HasOne(r => r.Book)
            .WithMany()
            .HasForeignKey(r => r.BookId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Review>()
            .Property(r => r.CreatedAt)
            .HasDefaultValueSql("GETDATE()");

        // Apply the configurations from the Configurations folder to seed the database with our default starter users and roles
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
