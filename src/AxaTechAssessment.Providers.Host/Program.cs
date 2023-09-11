using AxaTechAssessment.Providers.Host;
using AxaTechAssessment.Providers.Api;
using AxaTechAssessment.Providers.Infrastructure;
using AxaTechAssessment.Providers.Adapter;
using AxaTechAssessment.Providers.Application;
using AxaTechAssessment.Providers.Domain;

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
}

app.UseApiConfiguration();
app.Run();
