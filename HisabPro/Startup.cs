using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using HisabPro.Entities;
using HisabPro.IEntities;
using HisabPro.MapperProfile;
using HisabPro.Repository;
using HisabPro.Services;
using System.Text;

namespace HisabPro
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

            // Register IHttpContextAccessor
            services.AddHttpContextAccessor();
            services.AddScoped<IUserContext, UserContext>();

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<FilterService>();
            services.ConfigureAutoMappers();//services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped<IUserService, UserService>();

            services.AddDbContext<ApplicationDbContext>(o =>
            {
                o.UseSqlServer(_configuartion["connectionStrings:DefaultConnection"]);
            });

            // Add authentication services
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(options =>
                    {
                        options.LoginPath = "/Account/Login"; // Path to your login page
                    });

            // Configure JWT authentication
            var key = Encoding.ASCII.GetBytes(_configuartion["Jwt:Key"]);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = _configuartion["Jwt:Issuer"],
                    ValidAudience = _configuartion["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
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
                endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(name: "account", pattern: "account/{action=Login}/{id?}", defaults: new { controller = "Account", action = "Login" });
            });
            logger.LogInformation("Application started");
        }
    }
}
