using Microsoft.EntityFrameworkCore;
using QL_QuanBi_a_API.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

IConfigurationRoot cf = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory).
    AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();

builder.Services.AddDbContext<QlBidaContext>(opt => opt.UseSqlServer(cf.GetConnectionString("conn")));

builder.Services.AddCors(p => p.AddPolicy("MyCore", build =>
{
    //build.WithOrigins("http://localhost:4200/");
    build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("MyCore");

app.UseAuthorization();

app.MapControllers();

app.Run();
