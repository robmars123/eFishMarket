using EFM.Modules.Products.Infrastructure;

namespace EFM.Api.DependencyExtensions;

internal static class EnvinronmentConfiguration
{
    public static void EnvironmentConfig(this WebApplication app)
    {
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
    }
}
