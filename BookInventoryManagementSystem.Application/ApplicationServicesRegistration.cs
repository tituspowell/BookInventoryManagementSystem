using BookInventoryManagementSystem.Application.Services.Email;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BookInventoryManagementSystem.Application;

public static class ApplicationServicesRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        //// Add Identity services
        services.AddIdentity<ApplicationUser, IdentityRole>(options =>
        {
            options.SignIn.RequireConfirmedAccount = true;
            options.Password.RequireDigit = true;
            // Other Identity configurations
        })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        //services.AddScoped<ILeaveTypesService, LeaveTypesService>();
        //services.AddScoped<ILeaveAllocationsService, LeaveAllocationsService>();
        //services.AddScoped<ILeaveRequestsService, LeaveRequestsService>();
        //services.AddScoped<IPeriodsService, PeriodsService>();
        //services.AddScoped<IUserService, UserService>();
        services.AddTransient<IEmailSender, EmailSender>();

        return services;
    }
}
