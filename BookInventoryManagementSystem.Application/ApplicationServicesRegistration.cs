using BookInventoryManagementSystem.Application.Services;
using BookInventoryManagementSystem.Application.Services.Email;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BookInventoryManagementSystem.Application;

public static class ApplicationServicesRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Add AutoMapper
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        // Add email sender
        services.AddTransient<IEmailSender, EmailSender>();

        // Add our entity services
        services.AddScoped<IBooksService, BooksService>();

        return services;
    }
}
