using CurdApplicationWebApi.Component;
using CurdApplicationWebApi.Middleware;
using CurdApplicationWebApi.RepositoryLayer;
using CurdApplicationWebApi.Services;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region Dependency Injection

builder.Services.AddScoped<ICurdApplicationService, CurdApplicationService>();
builder.Services.AddScoped<IDatabaseAdapter, SqlAdapter>();
builder.Services.AddScoped<ICurdApplicationComponent, CurdApplicationComponent>();
builder.Services.AddScoped<IRedisCacheAdapter, RedisCacheAdapter>();
builder.Services.AddScoped<IDatabaseFactory, DatabaseFactory>();
builder.Services.AddScoped<IDatabaseAdapter, SqlAdapter>();
builder.Services.AddScoped<IDatabaseAdapter, ElasticSearchAdapter>();
#endregion

#region Swager

//builder.Services.AddMvcCore();
//builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
#endregion

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "My Api v1");
});
app.UseRouting();
app.UseApiRootLogging();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
// Configure the HTTP request pipeline.
app.Run();


