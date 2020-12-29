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
            try
            {
                Materiais tela = new Materiais(_handler);
                tela.ShowDialog();
            }
            catch (System.Exception ex)
            {
                if (ex.InnerException != null)
                    AppUtils.MensagemErro(ex.InnerException.Message);
                else
                    AppUtils.MensagemErro(ex.Message);
            }
        }

        private void BtnOrcamento_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Orcamento tela = new Orcamento(_handler);
                tela.ShowDialog();
            }
            catch (System.Exception ex)
            {
                if(ex.InnerException != null)
                    AppUtils.MensagemErro(ex.InnerException.Message);
                else
                    AppUtils.MensagemErro(ex.Message);
            }
        }

        private void BtnServicos_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ServicosDespesa tela = new ServicosDespesa(_handler);
                tela.ShowDialog();
            }
            catch (System.Exception ex)
            {
                if (ex.InnerException != null)
                    AppUtils.MensagemErro(ex.InnerException.Message);
                else
                    AppUtils.MensagemErro(ex.Message);
            }
        }
    }
}
