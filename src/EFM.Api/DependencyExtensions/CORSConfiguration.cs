namespace EFM.Api.DependencyExtensions;

internal static class CORSConfiguration
{
    public static void AddCORS(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAngularDevClient", policy =>
            {
                policy.WithOrigins(
                    "http://localhost:4200",
                    "http://localhost:8080",
                    "https://localhost:5003"
                )
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials(); //Only needed if you're using cookies or credentials
            });
        });
    }
}
