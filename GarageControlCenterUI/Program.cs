using GarageControlCenterBackend.DBContexts;
using GarageControlCenterBackend.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace GarageControlCenterUI
{
    internal static class Program
    {

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var serviceProvider = ConfigureServices();

            var garageService = serviceProvider.GetRequiredService<GarageService>();
            var userService = serviceProvider.GetRequiredService<UserService>();

            var mainForm = new MainForm(garageService, userService);

            Application.Run(mainForm);
        }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            services.AddDbContext<GarageDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddLogging(builder =>
            {
                builder.AddConfiguration(configuration.GetSection("Logging"));
                builder.AddConsole(); // Log to the console
                builder.AddDebug();// Log to debug output
                // You can add other logging providers here, like Azure App Service, etc.
            });

            services.AddScoped<GarageService>();
            services.AddScoped<UserService>();

            return services.BuildServiceProvider();
        }
    }
}