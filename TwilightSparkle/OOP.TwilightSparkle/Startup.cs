using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OOP.TwilightSparkle.Foundation.Builders;
using OOP.TwilightSparkle.Foundation.Ponies;
using OOP.TwilightSparkle.Middlewares;

namespace OOP.TwilightSparkle
{
    public sealed class Startup
    {
        private readonly IConfiguration _configuration;


        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IPegasusPonyBuilder, PegasusPonyBuilder>();
            services.AddSingleton<IPoniesService, CachedPoniesService>();

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().WithExposedHeaders("*");
                });
            });

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
            });
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseCors();

            app.UseMiddleware<ErrorLoggerMiddleware>(); //PATTERN Chain of Responsibility

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "API",
                    "api/{ControllerBase=Home}/{action=Index}");
            });
        }
    }
}