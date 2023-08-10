using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Project.VHM20.Data;
using Project.VHM20.Data.Persistence;
using Project.VHM20.Data.Persistence.Helpers;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configurations = builder.Configuration;

// Add services to the container.
services.AddCors();
services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddHttpContextAccessor();

services.AddDbContext<VhmDbContext>(option =>
    option.UseSqlServer(configurations.GetConnectionString("DefaultConnection"))
    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

services.Configure<JwtSettings>(configurations.GetSection("Jwt"));
services.AddVhmServices();

services.AddAutoMapper(typeof(MapperProfile));

var app = builder.Build();


app.UseCors(x => x
       .AllowAnyOrigin()
       .AllowAnyMethod()
       .AllowAnyHeader());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseMiddleware<JwtMiddleware>();

// app.UseAuthorization();

app.MapControllers();

app.Run();
