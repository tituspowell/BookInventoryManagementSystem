using BookInventoryManagementSystem.Application.Services.BooksReviewsSharedService;
using BookInventoryManagementSystem.Application.Services.Email;
using BookInventoryManagementSystem.Application.Services.Reviews;
using BookInventoryManagementSystem.Application.Services.Users;
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

        // Add our user service
        services.AddScoped<IUserService, UserService>();

        // Add our entity services
        services.AddScoped<IBooksService, BooksService>();
        services.AddScoped<IReviewsService, ReviewsService>();
        services.AddScoped<IBooksReviewsSharedService, BooksReviewsSharedService>();

        return services;
    }
}
