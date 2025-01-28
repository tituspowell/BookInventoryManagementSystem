using BookInventoryManagementSystem.Application;


var builder = WebApplication.CreateBuilder(args);

// Use our DataServicesRegistration extension method to register data services
DataServicesRegistration.AddDataServices(builder.Services, builder.Configuration);

// Use our AddApplicationServices extension method to register services from the Application project
ApplicationServicesRegistration.AddApplicationServices(builder.Services);

// Enable authorization stuff
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(Roles.AdminOrLibrarian, policy => policy.RequireRole(Roles.Administrator, Roles.Librarian));
});
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

//app.MapRazorPages()
//   .WithStaticAssets();

app.Run();
