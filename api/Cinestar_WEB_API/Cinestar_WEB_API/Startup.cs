using dataBase;
using WebPush;

namespace Cinestar_WEB_API
{
    public class Startup
    {
        public Startup(IConfigurationRoot configuration)
        {
            Configuration = configuration;
        }
        public IConfigurationRoot Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            var vapidDetails = new VapidDetails(
                Configuration.GetValue<string>("VapidDetails:Subject"),
                Configuration.GetValue<string>("VapidDetails:PublicKey"),
                Configuration.GetValue<string>("VapidDetails:PrivateKey"));
            services.AddTransient(c => vapidDetails);
            //services.AddControllers();
            services.AddDbContext<ApplicationDbContext>();
        }
        public void Configure(IApplicationBuilder app)
        {
            /*app.UseRouting();
            app.UseEndpoints(x => x.MapControllers());*/
        }
    }
}
