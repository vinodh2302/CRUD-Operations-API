using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProductApi.Context;
using ProductApi.Repository;
using ProductApi.Services;
using Microsoft.Extensions.Configuration;
namespace ProductApi
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
            services.AddControllersWithViews();
           
            services.AddDbContext<ProductContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("ProductDatabase")));
            

        }

        //My stuff
        //public void ConfigureServices(IServiceCollection services)
        //{
        //    //modify the ForumManageContext to your generated dbcontext model
        //    services.AddDbContext<ForumManageContext>();

        //    services.AddRazorPages();
        //}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseCors(
                   options => options.WithOrigins("http://localhost:4200").AllowAnyMethod()
                   .AllowAnyHeader()
                );
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "{controller=Home}/{action=Index}/{id?}");
            //});
        }
    }
}