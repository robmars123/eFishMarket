using EFM.Products.Api;
using EFM.Inventory.Api;

namespace EFM.Api.DependencyExtensions;

internal static class AppModuleConfiguration
{
    public static void AppConfig(this WebApplication app)
    {
        AppHttpPipeline(app);
        app.MapProductModule();
        app.MapInventoryModule();
    }

    private static void AppHttpPipeline(WebApplication app)
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

            app.ApplyMigrations();
        }

        app.UseCors("AllowAnyClient");
        app.UseHttpsRedirection();
        app.UseAuthorization();
    }

    public static void AddCORS(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAnyClient", policy =>
            {
                policy.WithOrigins(
                    "http://localhost:4200",
                    "http://localhost:8080",
                    "http://localhost:5000",
                    "https://localhost:7185",
                    "http://localhost:5173", //react dev
                    "http://localhost:5174", //react dev
                    "https://ambitious-mushroom-0c075a410.6.azurestaticapps.net"
                )
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials(); //Only needed if you're using cookies or credentials
            });
        });
    }
}
