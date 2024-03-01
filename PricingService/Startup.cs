using GlobalExceptionHandler.WebApi;
using Newtonsoft.Json;
using PricingService.DataAccess.Marten;
using PricingService.Infrastructure;
using PricingService.Infrastructure.Configuration;
using PricingService.Init;
using Steeltoe.Discovery.Client;

namespace PricingService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDiscoveryClient(Configuration);
            services.AddControllers()
                .AddNewtonsoftJson(opt => { opt.SerializerSettings.TypeNameHandling = TypeNameHandling.Auto; });

         
            services.AddMarten(Configuration.GetConnectionString("DefaultConnection"));
            services.AddPricingDemoInitializer();
            services.AddMediatR(options => options.RegisterServicesFromAssemblyContaining<Program>());
            services.AddLoggingBehavior();
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseGlobalExceptionHandler(cfg => cfg.MapExceptions());

            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseInitializer();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
