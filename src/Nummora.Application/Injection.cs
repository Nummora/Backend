using CloudinaryDotNet;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Nummora.Application.Services;
using Nummora.Application.Validators;

namespace Nummora.Application;

public static class Injection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IValidator, UserValidator>();
        
        
        services.Configure<CdnSettings>(opts => configuration
            .GetSection("CloudinarySettings"));
        
        services.AddSingleton(c =>
        {
            var cloudinarySettings = c.GetRequiredService<IOptions<CdnSettings>>().Value;
            var account = new Account(
                cloudinarySettings.CloudName,
                cloudinarySettings.ApiKey,
                cloudinarySettings.ApiSecret
            );

            return new Cloudinary(account);
        });
        
        return services;
    }
}