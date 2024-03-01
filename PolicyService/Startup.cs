using PolicyService.DataAccess.NHibernate;
using PolicyService.Messaging.RabbitMq;
using PolicyService.RestClients;
using Steeltoe.Discovery.Client;

namespace PolicyService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDiscoveryClient(Configuration);
            services.AddMvc()
                .AddNewtonsoftJson();
            services.AddMediatR(opts => opts.RegisterServicesFromAssemblyContaining<Startup>());
            services.AddPricingRestClient();
            services.AddNHibernate(Configuration.GetConnectionString("DefaultConnection"));
            services.AddRabbitListeners();
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseExceptionHandler("/error");

            if (!env.IsDevelopment()) app.UseHsts();

            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
