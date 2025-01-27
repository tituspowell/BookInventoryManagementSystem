using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BookInventoryManagementSystem.Application;

public static class ApplicationServicesRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        //services.AddScoped<ILeaveTypesService, LeaveTypesService>();
        //services.AddScoped<ILeaveAllocationsService, LeaveAllocationsService>();
        //services.AddScoped<ILeaveRequestsService, LeaveRequestsService>();
        //services.AddScoped<IPeriodsService, PeriodsService>();
        //services.AddScoped<IUserService, UserService>();
        //services.AddTransient<IEmailSender, EmailSender>();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        return services;
    }
}
