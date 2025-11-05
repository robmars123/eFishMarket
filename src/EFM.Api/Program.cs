using EFM.Api.DependencyExtensions;
using EFM.Modules.Products.Infrastructure;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.AddDependencyExtensions();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapEndpoints();

app.Run();
