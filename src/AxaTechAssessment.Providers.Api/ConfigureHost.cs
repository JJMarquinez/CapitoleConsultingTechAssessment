using Microsoft.AspNetCore.Builder;

namespace AxaTechAssessment.Providers.Api;

public static class ConfigureHost
{
    public static IApplicationBuilder UseApiConfiguration(this IApplicationBuilder app)
    {
        app.UseExceptionHandler()
            .UseRouting()
            .UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        return app;
    }
}