using System.Text.Json.Serialization;
using CloudinaryDotNet;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Nummora.Api;
using Nummora.Api.Config;
using Nummora.Application;
using Nummora.Application.Abstractions;
using Nummora.Application.Services;
using Nummora.Application.Validators;
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
//builder.Services.AddApplication(configuration);

builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));


builder.Services.Configure<CdnSettings>(opts => configuration
    .GetSection("CloudinarySettings").Bind(opts));
        
builder.Services.AddSingleton(c =>
{
    var cloudinarySettings = c.GetRequiredService<IOptions<CdnSettings>>().Value;
    var account = new Account(
        cloudinarySettings.CloudName,
        cloudinarySettings.ApiKey,
        cloudinarySettings.ApiSecret
    );

    return new Cloudinary(account);
});

//Cors
builder.Services.AddNummoraCors(corsPolicy);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IUserRolService, UserRoleService>();
builder.Services.AddScoped<IUserRoleRepository, UserRoleRepository>();
builder.Services.AddScoped<UserValidator>();





var app = builder.Build();

app.UseScalarUi();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseCors(corsPolicy);

app.Run();
