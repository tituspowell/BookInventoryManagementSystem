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
    //public DbSet<LeaveType> LeaveTypes { get; set; }
    //public DbSet<Period> Periods { get; set; }
    //public DbSet<LeaveAllocation> LeaveAllocations { get; set; }
    //public DbSet<LeaveRequestStatus> LeaveRequestStatus { get; set; } // This is a look-up table in case, say, you want to rename one without messing up the records
    //public DbSet<LeaveRequest> LeaveRequests { get; set; }


    // Overriding this method is how you seed the database with initial values
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // THESE WERE ALREADY COMMENTED OUT
        // The seeding can be done here but rapidly leads to a messy file. So instead we move the seeding to separate custom classes.
        // They can then be applied individually like this:
        //builder.ApplyConfiguration(new IdentityRoleConfiguration());
        //builder.ApplyConfiguration(new ApplicationUserConfiguration());
        //builder.ApplyConfiguration(new IdentityUserRoleConfiguration());
        //builder.ApplyConfiguration(new LeaveRequestStatusConfiguration());

        // Or all at once like this:
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
