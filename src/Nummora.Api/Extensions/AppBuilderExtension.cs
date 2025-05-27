using Scalar.AspNetCore;

namespace Nummora.Api;

public static class AppBuilderExtension
{
    public static void UseScalarUi(this WebApplication app)
    {
        app.UseSwagger(options =>
        {
            options.RouteTemplate = "/openapi/{documentName}.json";
        });
        app.MapScalarApiReference(opt =>
        {
            opt.Title = "Nummora";
            opt.Theme = ScalarTheme.Kepler;
            opt.HiddenClients = true;
            opt.HideModels = true;
            opt.DefaultHttpClient = new(ScalarTarget.CSharp, ScalarClient.HttpClient);
            opt.DotNetFlag = true;
            opt.Layout = ScalarLayout.Classic;
            opt.DefaultOpenAllTags = false;
        });
    }
}