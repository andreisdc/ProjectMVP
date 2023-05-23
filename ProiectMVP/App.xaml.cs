using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Windows;
using ProiectMVP.Data;
using ProiectMVP.Views;

namespace ProiectMVP
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IServiceProvider serviceProvider;

        public App()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(CreateYourDbContextOptions());
            services.AddSingleton<AppDbContext>();
            services.AddSingleton<AuthenticationView>();
        }

        private DbContextOptions<AppDbContext> CreateYourDbContextOptions()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return optionsBuilder.Options;
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider
                    .GetRequiredService<AppDbContext>();

                dbContext.Database.Migrate();
            }

            var mainWindow = serviceProvider.GetRequiredService<AuthenticationView>();
            mainWindow.Show();
            base.OnStartup(e);
        }
    }
}