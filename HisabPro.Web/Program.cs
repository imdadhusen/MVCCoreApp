using HisabPro;
using HisabPro.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Sinks.MSSqlServer;

public class Program
{
    private static void Main(string[] args)
    {
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        var configuration = new ConfigurationBuilder()
             .AddJsonFile("appsettings.json")
             .AddJsonFile($"appsettings.{environment}.json", optional: true)
             .Build();

        var logTo = configuration["Logging:LogTo"];
        var loggerConfiguration = new LoggerConfiguration().ReadFrom.Configuration(configuration);

        if (logTo == "File")
        {
            loggerConfiguration.WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day);
        }
        else if (logTo == "Database")
        {
            var sinkOptions = new MSSqlServerSinkOptions
            {
                TableName = "Logs",
                AutoCreateSqlTable = true
            };
            loggerConfiguration.WriteTo.MSSqlServer(
                configuration.GetConnectionString("DefaultConnection"),
                sinkOptions);
        }
        else
        {
            loggerConfiguration.WriteTo.Console();
        }


        if (environment == "Development")
        {
            // In development, you might want more detailed logs
            loggerConfiguration.MinimumLevel.Debug();
        }
        else
        {
            // In production, ensure detailed logs are avoided
            loggerConfiguration.MinimumLevel.Warning();
        }
        Log.Logger = loggerConfiguration.CreateLogger();

        try
        {
            Log.Information("Starting up the application");
            using (IHost host = CreateHostBuilder(args).Build())
            {
                using (var scope = host.Services.CreateScope())
                {
                    try
                    {
                        var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
                        // Apply pending migrations
                        context.Database.Migrate();

                        // Execute post-seed actions
                        context.ExecutePostSeedActions();
                    }
                    catch (Exception ex)
                    {
                        Log.Error(ex, "An error occurred seeding the DB.");
                        //var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                        //logger.LogError(ex, "An error occurred seeding the DB.");
                    }
                }
                host.Run();
            }
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Application start-up failed");
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }
    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
         .ConfigureLogging(logging =>
         {
             logging.ClearProviders(); // Clear default logging providers to avoid duplicate logs
         })
        .UseSerilog() // Use Serilog for logging
        .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}