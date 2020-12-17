using Store.Calculator.App.Views;
using Store.Calculator.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Store.Calculator.Infrastructure.Seeding;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace Store.Calculator.App
{
    /// <summary>
    /// Interação lógica para App.xaml
    /// </summary>
    public partial class App : Application
    {
        IServiceProvider ServiceProvider;
        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var menu = ServiceProvider.GetService<MenuInicial>();
            menu.Show();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IRepositoryMaterial, RepositoryMaterial>();
            services.AddDbContext<DbEstoqueContext>(
                options => options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=DbStoreCalculator;Trusted_Connection=true"));
            services.AddSingleton<MenuInicial>();
        }
    }
      
}
