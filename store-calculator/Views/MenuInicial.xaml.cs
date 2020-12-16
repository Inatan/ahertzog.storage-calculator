using Store.Calculator.Infrastructure;
using Store.Calculator.App.Views;
using System.Windows;

namespace Store.Calculator.App.Views
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MenuInicial : Window
    {

        private readonly IRepositoryMaterial _repo;
        public MenuInicial(IRepositoryMaterial repo)
        {
            _repo = repo;
            InitializeComponent();
        }

        private void BtnCadastro_Click(object sender, RoutedEventArgs e)
        {
            CadastroMateriaPrima tela = new CadastroMateriaPrima(_repo);
            tela.ShowDialog();
        }

        private void BtnFechar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
