using InvoiceApp.Infrastructure;
using InvoiceApp.Persistence;
using InvoiceApp.Application;
using InvoiceApp.API.Middlewares;
using InvoiceApp.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplicationServices()
    .AddInfrastructureServices()
    .AddPersistenceServices(builder.Configuration)
    .AddPresentation()
    .AddJwtAuthentication(builder.Configuration)
    .AddSwaggerDocs()
    .AddCorsPolicy();

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.UseSwaggerDocs();

app.UseMiddleware<ExceptionMiddleware>();
app.UseCors("AllowFrontend");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();