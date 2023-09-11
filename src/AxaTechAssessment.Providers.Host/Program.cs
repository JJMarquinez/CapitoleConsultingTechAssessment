using AxaTechAssessment.Providers.Host;
using AxaTechAssessment.Providers.Api;
using AxaTechAssessment.Providers.Infrastructure;
using AxaTechAssessment.Providers.Adapter;
using AxaTechAssessment.Providers.Application;
using AxaTechAssessment.Providers.Domain;
using AxaTechAssessment.Providers.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddDomainServices()
    .AddApplicationServices()
    .AddAdapterServices()
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices(builder.Configuration)
    .AddHostServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    if (app.Configuration.GetValue<bool>("InitialiseDatabase"))
    {
        // Initialise and seed database
        using (var scope = app.Services.CreateScope())
        {
            var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();
            await initialiser.InitialiseAsync();
        }
    }
}

app.UseApiConfiguration();
app.Run();
