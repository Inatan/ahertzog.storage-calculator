using Store.Calculator.Services.Handlers;
using System.Windows;

namespace Store.Calculator.App.Views
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MenuInicial : Window
    {
        private readonly ICadastroMaterialHandler _handler;
        public MenuInicial(ICadastroMaterialHandler handler)
        {
            _handler = handler;
            InitializeComponent();
        }

        private void BtnCadastro_Click(object sender, RoutedEventArgs e)
        {
            CadastroMateriaPrima tela = new CadastroMateriaPrima(_handler);
            tela.ShowDialog();
        }

        private void BtnFechar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
