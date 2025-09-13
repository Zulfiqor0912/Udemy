using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Udemy.API.Extension;
using Udemy.Application.Extension;
using Udemy.Domain.Entities;
using Udemy.Infrastructure.Extension;
using Udemy.Infrastructure.Persistence;
using Udemy.Infrastructure.Seeders;

var builder = WebApplication.CreateBuilder(args);
builder.AddPresentation();

builder.Services.AddAplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddIdentity<User, IdentityRole<Guid>>()
            .AddEntityFrameworkStores<UdemyDbContext>()
            .AddDefaultTokenProviders();

var app = builder.Build();
var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<IUdemySeeder>();
await seeder.Seed();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Udemy.API V1");
    });
}
// Configure the HTTP request pipeline.



app.UseExceptionHandler(appError =>
{
    appError.Run(async context =>
    {
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Response.ContentType = "application/json";

        var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
        if (contextFeature != null)
        {
            await context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(new
            {
                StatusCode = context.Response.StatusCode,
                Message = "Internal Server Error",
                Detail = contextFeature.Error.Message
            }));
        }
    });
});


app.MapGroup("api/identity");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();