using Nummora.Api;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseScalarUi();
}

app.Run();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

//TODO: configurar cors
app.UseCors();
