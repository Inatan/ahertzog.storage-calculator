using Ninject;
using Store.Calculator.Infrastructure;
using System;
using System.Windows;

namespace store_calculator
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
            Current.MainWindow.Show();
        }

        private void ComposeObjects()
        {
            
        }

        private void ConfigureContainer()
        {
            container = new StandardKernel();
            container.Bind<IRepositoryMaterial>().To<RepositoryMaterial>().InTransientScope();
        }
    }
}
