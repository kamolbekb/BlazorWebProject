using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Nafaqa.Application;
using Microsoft.Extensions.DependencyInjection;
using Nafaqa.Application.Models.Validators;
using Nafaqa.DataAccess;
using Nafaqa.API.Filters;
using Nafaqa.API.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();
builder.Services.AddHttpClient();
builder.Services.AddControllers(
    config => config.Filters.Add(typeof(ValidateModelAttribute))
);

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining(typeof(IValidationsMarker));

builder.Services.AddDbContext<DbContext>(options =>
    options.UseNpgsql("ConnectionString"));

builder.Services.AddSwaggerGen();

builder.Services.AddLogging();

builder.Services.AddDataAccess(builder.Configuration)
    .AddApplication(builder.Environment);

var app = builder.Build();

using var scope = app.Services.CreateScope();

app.UseSwagger();
app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "N-Tier V1"); });

app.UseCors(corsPolicyBuilder =>
    corsPolicyBuilder.WithOrigins("https://192.168.31.172:7223")
        .AllowAnyMethod()
        .AllowAnyHeader()
);

app.UseHttpsRedirection();

app.UseRouting();

app.UseMiddleware<PerformanceMiddleware>();

app.UseMiddleware<TransactionMiddleware>();

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.MapControllers();

app.Run();

namespace N_Tier.API
{
    public partial class Program { }
}
