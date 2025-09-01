using Udemy.API.Extension;
using Udemy.Application.Extension;
using Udemy.Infrastructure.Extension;

var builder = WebApplication.CreateBuilder(args);
builder.AddPresentation();

builder.Services.AddAplication();
builder.Services.AddInfrastructure(builder.Configuration);


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Udemy.API V1");
    });
}
// Configure the HTTP request pipeline.


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();