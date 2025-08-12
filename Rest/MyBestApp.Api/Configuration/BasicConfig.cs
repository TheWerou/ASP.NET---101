using Microsoft.OpenApi.Models;
using Serilog;

namespace MyBestApp.Api.Configuration
{
    public static class BasicConfig
    {
        public static WebApplicationBuilder BasicConfiguration(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();

            builder.Host
                .UseSerilog((ctx, lc) => 
                    lc
                        .ReadFrom.Configuration(ctx.Configuration));

            var paths = builder.Configuration.GetSection("CORS-Paths").Get<string[]>();
            if (paths != null)
                builder.Services.AddCors(options =>
                {
                    options.AddPolicy("CorsPolicy",
                        builder => builder.WithOrigins(paths)
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials()
                        .SetIsOriginAllowed((host) => true));
                });

            return builder;
        }

        public static WebApplicationBuilder AddSwaggerSupport(this WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "MyBestApp API",
                    Version = "v1",
                    Description = "Application created with love",
                });
            });

            return builder;
        }
    }
}
