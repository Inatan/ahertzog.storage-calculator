using Store.Calculator.App.Views;
using Store.Calculator.Infrastructure;
using Store.Calculator.Infrastructure.Repository;
using Store.Calculator.Infrastructure.Seeding;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using Store.Calculator.Services.Handlers;
using Store.Calculator.Services;
using System.Globalization;
using System.Windows.Markup;

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
            DatabaseGenerator.Seed();
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            FrameworkElement.LanguageProperty.OverrideMetadata(
                typeof(FrameworkElement),
                new FrameworkPropertyMetadata(
                    XmlLanguage.GetLanguage(
                        CultureInfo.CurrentCulture.IetfLanguageTag
                    )
                )
            );
            var menu = ServiceProvider.GetService<MenuInicial>();
            menu.Show();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IRepositoryMaterial, RepositoryMaterial>();
            services.AddTransient<IRepositoryValorServico, RepositoryValorServico>();
            services.AddTransient<IMaterialHandler, MaterialHandler>();
            services.AddTransient<IValorServicoHandler, ValorServicoHandler>();
            services.AddSingleton<ServicesControl>();
            services.AddDbContext<DbEstoqueContext>();
            services.AddSingleton<MenuInicial>();
        }
    }
      
}
