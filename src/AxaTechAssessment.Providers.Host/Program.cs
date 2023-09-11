using AxaTechAssessment.Providers.Host;
using AxaTechAssessment.Providers.Api;
using AxaTechAssessment.Providers.Infrastructure;
using AxaTechAssessment.Providers.Adapter;
using AxaTechAssessment.Providers.Application;
using AxaTechAssessment.Providers.Domain;
using AxaTechAssessment.Providers.Infrastructure.Persistence;
using AxaTechAssessment.Providers.Host.Extensions;

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
    await app.InitialiseDatabaseAsync();
}

app.UseApiConfiguration();
app.Run();
