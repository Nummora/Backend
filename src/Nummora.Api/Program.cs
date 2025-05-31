using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Nummora.Api;
using Nummora.Api.Config;
using Nummora.Application.Abstractions;
using Nummora.Infrastructure;
using Nummora.Infrastructure.Data;
using Nummora.Infrastructure.Persistence;
using Nummora.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers()
    .AddJsonOptions(opt => opt.JsonSerializerOptions.Converters.Add((new JsonStringEnumConverter())));

const string corsPolicy = "NummoraCors";

//services
var configuration = builder.Configuration;
//string connectionString = configuration.GetConnectionString("DefaultConnection") ?? string.Empty;

//builder.Services.AddInfrastructure(configuration, connectionString);

builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

//Cors
builder.Services.AddNummoraCors(corsPolicy);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseScalarUi();
}


app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseCors(corsPolicy);

app.Run();
