using carstructure.WebApp._2_Services.ServiceClass;
using carstructure.WebApp._2_Services.ServiceInterface;
using carstructure.WebApp._3_BusinessLogic.BusinessClass;
using carstructure.WebApp._3_BusinessLogic.BusinessInterface;
using carstructure.WebApp._4_DataAccess;
using carstructure.WebApp._4_DataAccess.DataAccessClass;
using carstructure.WebApp._4_DataAccess.DataAccessInterface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




builder.Services.AddTransient<AudiInterface, AudiService>();
builder.Services.AddTransient<AudiBusinessInterface, AudiBusinessClass>();
builder.Services.AddTransient<ICarRepository, CarRepository>();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<Context>(x => x.UseSqlServer(connectionString));




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
