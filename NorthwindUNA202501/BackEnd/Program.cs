using BackEnd.Services.Implementations;
using BackEnd.Services.Interfaces;
using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Serilog

    builder.Logging.ClearProviders();
builder.Host.UseSerilog((ctx, lc) => lc
                        .WriteTo
                        .File("logs/logsbackend", rollingInterval: RollingInterval.Day)
                        .MinimumLevel.Error());
        
        


#endregion


#region DI
builder.Services.AddDbContext<NorthWindContext>(
                                options=>
                                options.UseSqlServer(
                                    builder
                                    .Configuration
                                    .GetConnectionString("DefaultConnection")
                                        ));
builder.Services.AddScoped<IShipperDAL, ShipperDALImpl>();  
builder.Services.AddScoped<IUnidadDeTrabajo, UnidadDeTrabajo>();
builder.Services.AddScoped<ICategoryDAL, CategoryDALImpl>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddScoped<IProductDAL, ProductDALImpl>();
builder.Services.AddScoped<IProductService, ProductService>();


builder.Services.AddScoped<ISupplierDAL, SupplierDALImpl>();
builder.Services.AddScoped<ISupplierService, SupplierService>();





#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
