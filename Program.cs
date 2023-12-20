using Inventory.Data;
using Inventory.Extensions;
using Inventory.Services;
using Inventory.Services.IServices;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Inventory.Profiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure DbContext
builder.Services.AddDbContext<InventoryContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("myconnection");

    if (connectionString != null)
    {
        options.UseSqlServer(connectionString);
    }
    else
    {
        // Handle the case where the connection string is null (log an error, throw an exception, etc.)
        // For example, you can throw an InvalidOperationException:
        throw new InvalidOperationException("Connection string is null.");
    }
});

// Configure Dependency Injection
builder.Services.AddScoped<IProduct, ProductService>();
builder.Services.AddScoped<IOrder, OrderService>();
builder.Services.AddScoped<IUser, UserService>();
builder.Services.AddScoped<IJwt, JwtService>();

// Configure AutoMapper
ConfigureAutoMapper(builder.Services);

// Configure Swagger, Authentication, and Authorization
builder.AddSwaggenGenExtension();
builder.AddAuth();
builder.AddAdminPolicy();

// Create the application
var app = builder.Build();

// Configure the application
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();

// Separate method to configure AutoMapper
void ConfigureAutoMapper(IServiceCollection services)
{
    services.AddAutoMapper(typeof(UserProfile).Assembly /* other assemblies if needed */);
    // Fallback to scan all assemblies if needed
    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
}

