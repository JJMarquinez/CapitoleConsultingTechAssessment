using AxaTechAssessment.Providers.Infrastructure.Persistence;

namespace AxaTechAssessment.Providers.Host.Extensions;

public static class WebApplicationExtension
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        if (app.Configuration.GetValue<bool>("InitialiseDatabase"))
        {
            using var scope = app.Services.CreateScope();

            var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();

            await initialiser.InitialiseAsync();
        }
    }
}
