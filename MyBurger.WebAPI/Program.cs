using Microsoft.EntityFrameworkCore;
using MyBurger.WebAPI.Context;
using MyBurger.WebAPI.Repositories;
using MyBurger.WebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

builder.Services.AddTransient<IngrediantRepository>();
builder.Services.AddTransient<IngrediantService>();

builder.Services.AddTransient<ProductRepository>();
builder.Services.AddTransient<ProductService>();

builder.Services.AddTransient<BR_Product_IngrediantRepository>();
builder.Services.AddTransient<BR_Product_IngrediantService>();

builder.Services.AddTransient<MenuRepository>();
builder.Services.AddTransient<MenuService>();

builder.Services.AddTransient<BR_Menu_ProductRepository>();
builder.Services.AddTransient<BR_Menu_ProductService>();

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();

app.UseCors(a => a.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

app.MapControllers();

app.Run();
