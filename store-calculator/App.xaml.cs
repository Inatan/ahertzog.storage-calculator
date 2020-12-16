using Store.Calculator.App.Views;
using Store.Calculator.Infrastructure;
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
        public IServiceProvider ServiceProvider { get; private set; }


        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();

            Current.MainWindow = ServiceProvider.GetService<MenuInicial>();
            Current.MainWindow.Show();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IRepositoryMaterial, RepositoryMaterial>();
        }
    }
      
}
