namespace EFM.Api.DependencyExtensions;

internal static class CORSConfiguration
{
    public static void AddCORS(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAnyClient", policy =>
            {
                policy.WithOrigins(
                    "http://localhost:4200",
                    "http://localhost:8080",
                    "http://localhost:5000"
                )
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials(); //Only needed if you're using cookies or credentials
            });
        });
    }
}
