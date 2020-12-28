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
using Microsoft.EntityFrameworkCore;
using System.Configuration;

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
            try
            {
                //DatabaseGenerator.Seed();
                ServiceCollection services = new ServiceCollection();
                ConfigureServices(services);
                ServiceProvider = services.BuildServiceProvider();
            }
            catch (Exception ex)
            {
                AppUtils.MensagemErro($"Erro ao inicalizar o app: {ex.Message}");
             
            }
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            try
            {
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
            catch (Exception ex)
            {
                AppUtils.MensagemErro($"Erro ao conectar ao banco {ex.Message}");
                var menu = new MenuInicial(new ServicesControl(new MaterialHandler(new RepositoryMaterial(new DbEstoqueContext())), new ValorServicoHandler(new RepositoryValorServico(new DbEstoqueContext()))));
            }
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IRepositoryMaterial, RepositoryMaterial>();
            services.AddTransient<IRepositoryValorServico, RepositoryValorServico>();
            services.AddTransient<IMaterialHandler, MaterialHandler>();
            services.AddTransient<IValorServicoHandler, ValorServicoHandler>();
            services.AddSingleton<ServicesControl>();
            services.AddDbContext<DbEstoqueContext>(
            options => {
                options.UseSqlServer(
                    ConfigurationManager.ConnectionStrings["DbStoreCalculator"].ConnectionString
                //Configuration.GetConnectionString("DefaultConnection")
                ) ;
            }, ServiceLifetime.Transient);
            services.AddSingleton<MenuInicial>();
        }
    }
      
}
