using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using SampleMvcCoreApp.Entities;
using SampleMvcCoreApp.MapperProfile;
using SampleMvcCoreApp.Repository;

namespace SampleMvcCoreApp
{
    public class Startup
    {
        //private readonly IConfiguration _configuartion;
        public IConfiguration _configuartion { get; }

        public Startup(IConfiguration configuartion)
        {
            _configuartion = configuartion;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddControllersWithViews();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<FilterService>();
            services.ConfigureAutoMappers();//services.AddAutoMapper(typeof(MappingProfile));

            services.AddDbContext<EmployeeDbContext>(o =>
            {
                o.UseSqlServer(_configuartion["connectionStrings:DefaultConnection"]);
            });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.  
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Images")),
                RequestPath = new PathString("/app-images")
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            logger.LogInformation("Application started");
        }
    }
}
