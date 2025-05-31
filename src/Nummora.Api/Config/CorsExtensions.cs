namespace Nummora.Api.Config;

public static class CorsExtensions
{
    public static IServiceCollection AddNummoraCors(this IServiceCollection services, string policyCorsName)
    {
        services.AddCors(policy =>
            policy.AddPolicy(name: policyCorsName, builder =>
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()));
        return services;
    }
}