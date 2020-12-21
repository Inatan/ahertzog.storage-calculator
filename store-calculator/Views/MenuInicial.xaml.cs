using Store.Calculator.Services;
using System.Windows;

namespace Store.Calculator.App.Views
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MenuInicial : Window
    {
        private readonly ServicesControl _handler;
        public MenuInicial(ServicesControl handler)
        {
            _handler = handler;
            InitializeComponent();
        }

        private void BtnCadastro_Click(object sender, RoutedEventArgs e)
        {
            CadastroMateriaPrima tela = new CadastroMateriaPrima(_handler);
            tela.ShowDialog();
        }

        private void BtnOrcamento_Click(object sender, RoutedEventArgs e)
        {
            Orcamento tela = new Orcamento(_handler);
            tela.ShowDialog();
        }

        private void BtnServicos_Click(object sender, RoutedEventArgs e)
        {
            ServicosDespesa tela = new ServicosDespesa(_handler);
            tela.ShowDialog();
        }
    }
}
