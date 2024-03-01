using PolicySearchService.DataAccess.ElasticSearch;
using PolicySearchService.Messaging.RabbitMq;
using PolicyService.Api.Events;
using Steeltoe.Discovery.Client;

namespace PolicySearchService
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
            services.AddElasticSearch(Configuration.GetConnectionString("ElasticSearchConnection"));
            services.AddRabbitListeners();
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();

            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRabbitListeners(new List<Type> { typeof(PolicyCreated) });
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
