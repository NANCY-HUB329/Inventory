using Inventory.Data;
using Inventory.Extensions;
using Inventory.Services;
using Inventory.Services.IServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.             
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Service for connection to the Database.
builder.Services.AddDbContext<InventoryContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("productConnection"));
});

// Register Services for DI.
builder.Services.AddScoped<IProduct, ProductService>();
builder.Services.AddScoped<IOrder, OrderService>();
builder.Services.AddScoped<IUser, UserService>();
builder.Services.AddScoped<IJwt, JwtService>();

// ...





builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.AddSwaggenGenExtension();
builder.AddAuth();
builder.AddAdminPolicy();

var app = builder.Build();

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
