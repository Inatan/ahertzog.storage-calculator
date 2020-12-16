using Ninject;
using Store.Calculator.App.Views;
using Store.Calculator.Infrastructure;
using Store.Calculator.Infrastructure.Seeding;
using System.Windows;

namespace Store.Calculator.App
{
    /// <summary>
    /// Interação lógica para App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IKernel container;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ConfigureContainer();
            ComposeObjects();
            DatabaseGenerator.Seed();
            Current.MainWindow.Show();
        }

        private void ComposeObjects()
        {
            Current.MainWindow = this.container.Get<MenuInicial>();
        }

        private void ConfigureContainer()
        {
            container = new StandardKernel();
            container.Bind<IRepositoryMaterial>().To<RepositoryMaterial>().InTransientScope();
        }
    }
}
