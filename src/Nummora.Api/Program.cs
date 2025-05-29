using Nummora.Api;
using Nummora.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

//services
var configuration = builder.Configuration;

builder.Services.AddInfrastructure(configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseScalarUi();
}


app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

//TODO: configurar cors
app.UseCors();

app.Run();
