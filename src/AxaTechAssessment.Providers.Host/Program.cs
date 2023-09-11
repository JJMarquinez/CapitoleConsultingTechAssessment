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

//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();
app.UseApiConfiguration();
app.Run();
