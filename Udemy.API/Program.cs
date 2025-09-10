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

builder.Services.AddIdentityApiEndpoints<User>()
            .AddRoles<IdentityRole<Guid>>()
            .AddEntityFrameworkStores<UdemyDbContext>();

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





app.MapGroup("api/identity").MapIdentityApi<User>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();