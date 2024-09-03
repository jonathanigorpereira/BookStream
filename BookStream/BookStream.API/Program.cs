using BenchmarkDotNet.Running;
using BookStream.API;
using BookStream.API.ExceptionHandler;
using BookStream.Application;
using BookStream.Infrastructure;
using BookStream.Infrastructure.Persistence.Repositories;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IConfigService, ConfigService>();

builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

builder.Services.AddExceptionHandler<ApiExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "BookStream.API",
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "Jonathan Pereira",
            Email = "jonathanigorpereira@gmail.com",
            Url = new Uri("https://www.linkedin.com/in/jonathan-igor-bockorny-pereira/")
        }
    });
    
    var xmFile = "BookStream.API.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmFile);  
    c.IncludeXmlComments(xmlPath);
});

builder.AddServiceDefaults();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

BenchmarkRunner.Run<BookRepository>();

await app.RunAsync();
