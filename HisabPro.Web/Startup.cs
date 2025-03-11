using HisabPro.Common;
using HisabPro.Constants;
using HisabPro.Constants.Resources;
using HisabPro.Entities.IEntities;
using HisabPro.Entities.Models;
using HisabPro.Repository;
using HisabPro.Repository.Implements;
using HisabPro.Repository.Interfaces;
using HisabPro.Services.Implements;
using HisabPro.Services.Interfaces;
using HisabPro.Web.Entities;
using HisabPro.Web.Helper;
using HisabPro.Web.MapperProfile;
using HisabPro.Web.Middleware;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;
using System.Globalization;
using System.Net;
using System.Reflection;

namespace HisabPro
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Bind the AppSettings section to the AppSettings class
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddSingleton<AppSettings>(sp => sp.GetRequiredService<IOptions<AppSettings>>().Value);
            //For localization
            //services.AddSingleton<SharedResourceService>();

            services.AddMvc();
            services.AddControllers(options =>
            {
                options.Filters.Add<ValidateModelStateFilter>();
                options.Filters.Add<CustomExceptionFilter>();
            });
            services.AddControllersWithViews()
                .AddViewLocalization() // Enable view localization
                .AddDataAnnotationsLocalization(options =>
                {
                    options.DataAnnotationLocalizerProvider = (type, factory) =>
                    {
                        var assemblyName = new AssemblyName(typeof(SharedResource).GetTypeInfo().Assembly.FullName);
                        return factory.Create("SharedResource", assemblyName.Name);
                    };
                })
                .AddRazorOptions(options =>
                {
                    options.ViewLocationFormats.Add("/Views/Public/{1}/{0}.cshtml");
                    options.ViewLocationFormats.Add("/Views/Private/{1}/{0}.cshtml");
                    options.ViewLocationFormats.Add("/Views/Shared/{0}.cshtml");
                });
            // Configure localization options
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            //services.AddTransient(typeof(LocalizedEnumResolver<,>));
            //services.AddAutoMapper(typeof(MappingProfile));
            // Register custom localizer
            services.AddSingleton<ISharedViewLocalizer, SharedViewLocalizer>();

            //.Configure<ResourceManagerStringLocalizerOptions>(options => options.IgnoreCase = true);

            //services.AddControllers().AddNewtonsoftJson(options =>
            //{
            //    options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
            //    options.SerializerSettings.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto; // Enables polymorphism
            //});

            // Register IHttpContextAccessor
            services.AddHttpContextAccessor();
            services.AddTransient<IAuthService, AuthService>();
            services.AddSingleton<EmailService>();
            services.AddScoped<IUserContext, UserContext>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(UpdateRepository<,>));

            services.AddScoped<IDashboardService, DashboardService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IIncomeService, IncomeService>();
            services.AddScoped<IExpenseService, ExpenseService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IReportService, ReportService>();
            services.AddScoped<IExportDataService, ExportDataService>();
            services.AddKeyedScoped<IExportService, ExportToPDFService>("PDF");
            services.AddKeyedScoped<IExportService, ExportToHTMLService>("HTML");
            services.AddKeyedScoped<IExportService, ExportToExcelService>("Excel");


            services.AddScoped<FilterService>();
            services.ConfigureAutoMappers();//services.AddAutoMapper(typeof(MappingProfile));

            services.AddDbContext<ApplicationDbContext>(o =>
            {
                o.UseSqlServer(Configuration.GetConnectionString(AppConst.Configs.DatabaseConnectionString));
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
                // Require 'SuperAdmin' role for this policy
                options.AddPolicy(AuthorizePolicy.RequiredRoleSuperAdmin, policy => policy.RequireRole(AuthorizePolicy.NameRoleSuperAdmin));
                // Require 'Admin' role for this policy
                options.AddPolicy(AuthorizePolicy.RequiredRoleAdmin, policy => policy.RequireRole(AuthorizePolicy.NameRoleAdmin));
                // Require 'User' role for this policy
                options.AddPolicy(AuthorizePolicy.RequiredRoleUser, policy => policy.RequireRole(AuthorizePolicy.NameRoleUser));
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
                app.UseExceptionHandler(AppConst.Views.Error);
                app.UseHsts();
            }

            // Define the supported cultures
            var supportedCultures = new[] { new CultureInfo("en-US"), new CultureInfo("gu-IN") };
            // Configure the Request Localization options
            var requestLocalizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en-US"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures,
                // Explicitly specifying the type for RequestCultureProviders
                RequestCultureProviders =
                [
                    new QueryStringRequestCultureProvider(),
                    new CookieRequestCultureProvider(),
                    new AcceptLanguageHeaderRequestCultureProvider()
                ]
            };
            app.UseRequestLocalization(requestLocalizationOptions);

            //--app.UseMiddleware<CultureMiddleware>();

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

            // Register the remember me middleware after login
            app.UseMiddleware<RememberMe>();
            // Register the Password expirey middleware after login
            app.UseMiddleware<PasswordExpiry>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}");

                endpoints.MapControllerRoute(name: "dashboard", pattern: "dashboard/{action=Index}", defaults: new { controller = "Dashboard" });
                endpoints.MapControllerRoute(name: "user", pattern: "user/{action=Login}", defaults: new { controller = "User", action = "Login" });
                endpoints.MapControllerRoute(name: "account", pattern: "account/{controller=Account}/{action=Index}", defaults: new { controller = "Account", action = "Index" });
                endpoints.MapControllerRoute(name: "income", pattern: "income/{controller=Income}/{action=Index}", defaults: new { controller = "Income", action = "Index" });
                endpoints.MapControllerRoute(name: "expense", pattern: "expense/{controller=Expense}/{action=Index}", defaults: new { controller = "Expense", action = "Index" });
                endpoints.MapControllerRoute(name: "import", pattern: "import/{controller=Import}/{action=Expense}", defaults: new { controller = "Import", action = "Expense" });
            });

            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            logger.LogInformation("Application started");
        }
    }
}
