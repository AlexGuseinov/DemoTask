using Application;
using Application.CrossCuttingConcerns.Exceptions.Extensions;
using Infrastructure;
using Microsoft.OpenApi.Models;
using Persistence;
using MailService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo APP", Version = "v1" });
});

builder.Services.AddApplicationDepdendencies(builder.Configuration);
builder.Services.AddPersistenceDependencies(builder.Configuration);
builder.Services.AddInfrastructureDependencies();
builder.Services.AddMailService(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseExceptionHandling();

app.UseAuthorization();

app.MapControllers();

app.Run();
