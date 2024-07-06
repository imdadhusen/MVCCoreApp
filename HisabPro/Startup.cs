using HisabPro.Constants;
using HisabPro.Entities;
using HisabPro.IEntities;
using HisabPro.MapperProfile;
using HisabPro.Middleware;
using HisabPro.Repository;
using HisabPro.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
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
            services.AddTransient<AuthService>();
            services.AddScoped<IUserContext, UserContext>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<FilterService>();
            services.ConfigureAutoMappers();//services.AddAutoMapper(typeof(MappingProfile));

            services.AddDbContext<ApplicationDbContext>(o =>
            {
                o.UseSqlServer(_configuartion[AppConst.Configs.DatabaseConnectionString]);
            });

            // Configure JWT authentication
            //var key = Encoding.ASCII.GetBytes(_configuartion[AppConst.Configs.JwtKey]);
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = AppConst.Views.Login; // Path to your login page
                options.LogoutPath = AppConst.Views.Logout;
                options.AccessDeniedPath = AppConst.Views.AccessDenied;
                options.Events.OnRedirectToLogin = context =>
                {
                    context.HttpContext.Response.Redirect(AppConst.Views.Unauthorized);
                    return Task.CompletedTask;
                };
                options.Events.OnRedirectToAccessDenied = context =>
                {
                    context.HttpContext.Response.Redirect(AppConst.Views.AccessDenied);
                    return Task.CompletedTask;
                };
            });
            //.AddJwtBearer(options =>
            //{
            //    options.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuer = true,
            //        ValidateAudience = true,
            //        ValidateLifetime = true,
            //        ValidateIssuerSigningKey = true,
            //        ValidIssuer = _configuartion[AppConst.Configs.JwtIssuer],
            //        ValidAudience = _configuartion[AppConst.Configs.JwtAudience],
            //        IssuerSigningKey = new SymmetricSecurityKey(key)
            //    };
            //});
            services.AddAuthorization(options =>
            {
                // Require 'Admin' role for this policy
                options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
                // Require 'User' role for this policy
                options.AddPolicy("RequireUserRole", policy => policy.RequireRole("User"));
            });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.  
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            // Register the exception handling middleware
            app.UseMiddleware<ExceptionHandler>();
            // Register the remember me middleware
            app.UseMiddleware<RememberMe>();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(AppConst.Views.Error);
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
            app.UseStatusCodePages(context =>
            {
                var response = context.HttpContext.Response;
                if (response.StatusCode == (int)HttpStatusCode.Unauthorized || response.StatusCode == (int)HttpStatusCode.Forbidden)
                    response.Redirect(AppConst.Views.Unauthorized);
                return Task.CompletedTask;
            });
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(name: "account", pattern: "account/{action=Login}/{id?}", defaults: new { controller = "Account", action = "Login" });
                endpoints.MapControllerRoute(name: "employee", pattern: "employee/{action=Index}/{id?}");

            });

            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            logger.LogInformation("Application started");
        }
    }
}
