namespace Nummora.Api;

public static class Injection
{
   public static IServiceCollection AddApi(this IServiceCollection services)
   {
      services.AddCors(policy =>
         policy.AddPolicy("NummoraCors", builder =>
            builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader()));
      return services;
   }
}