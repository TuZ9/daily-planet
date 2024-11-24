using daily_planet_application.AutoMapper;
using daily_planet_application.Static;
using daily_planet_infra.Extensions;
using daily_planet_infra.Ioc.Swagger;
using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

SwaggerConfiguration.AddSwagger(builder.Services);
RunTimeConfig.SetConfigs(builder.Configuration);
builder.Services.AddHttpClients();
builder.Services.AddServices();
builder.Services.AddAutoMapper(typeof(EntityToDtoMapper), typeof(DtoToEnityMapper));
builder.Services.AddMemoryCache();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHealthChecks();
builder.Services.AddCors(options => options.AddPolicy("All", opt => opt
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials()
                        .SetIsOriginAllowed(hostname => true)));

builder.WebHost.UseKestrel(so =>
{
    so.Limits.KeepAliveTimeout = TimeSpan.FromSeconds(10000);
    so.Limits.MaxRequestBodySize = 52428800;
    so.Limits.MaxConcurrentConnections = 100;
    so.Limits.MaxConcurrentConnections = 100;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHangfire(x =>
{
    x.SetDataCompatibilityLevel(CompatibilityLevel.Version_170);
    x.UseSimpleAssemblyNameTypeSerializer();
    x.UseRecommendedSerializerSettings();
    x.UseMemoryStorage();
});


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("../swagger/v1/swagger.json", "v1");
    c.RoutePrefix = string.Empty;
});

app.UseHealthChecks("/env", new HealthCheckOptions
{
    ResultStatusCodes =
                {
                        [HealthStatus.Healthy] = StatusCodes.Status200OK,
                        [HealthStatus.Degraded] = StatusCodes.Status200OK,
                        [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable
                },
    ResponseWriter = async (context, report) =>
    {
        var result = JsonSerializer.Serialize(new
        {
            //Environment = env.EnvironmentName,
            SystemEnvironment = Environment.GetEnvironmentVariable("dev"),
        });
        //context.Response.ContentType = MediaTypeNames.Application.Json;
        await context.Response.WriteAsync(result);
    }
});

var serviceProvider = builder.Services.BuildServiceProvider();
HangireJobs.RunHangFireJob(serviceProvider);
app.UseRouting();
app.UseAuthentication();
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors("All");
//app.MapHealthChecks();
app.MapControllers();
app.Run();
