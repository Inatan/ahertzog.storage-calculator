using System.Windows;
using System.Windows.Input;
using Store.Calculator.Model;
using Store.Calculator.Model.Utils;

namespace store_calculator.Views
{
    /// <summary>
    /// Lógica interna para CadastroMateriaPrima.xaml
    /// </summary>
    public partial class CadastroMateriaPrima : Window
    {
        public CadastroMateriaPrima()
        {
            InitializeComponent();
        }

        private void DecimalValidationValorFrete(object sender, TextCompositionEventArgs e)
        {
            e.Handled = EventsUtils.ValidaDecimal(txtValorFrete.Text, e.Text);
        }

        private void DecimalValidationValorPago(object sender, TextCompositionEventArgs e)
        {
            e.Handled = EventsUtils.ValidaDecimal(txtValorPago.Text, e.Text);
        }

        private void NumeroValidationQuantidade(object sender, TextCompositionEventArgs e)
        {
            e.Handled = EventsUtils.ValidaNumero(txtQuantidade.Text, e.Text);
        }

        private void NumeroValidationQuantoFaz(object sender, TextCompositionEventArgs e)
        {
            e.Handled = EventsUtils.ValidaNumero(txtQuantoFaz.Text, e.Text);
        }


        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TextInputValorFrete(object sender, TextCompositionEventArgs e)
        {
            txtValorUnidade.Text = EstoqueMateriaPrima.CalculaValorUnitario(txtQuantidade.Text, txtQuantoFaz.Text, txtValorPago.Text, txtValorFrete.Text);
        }

        private void TxtValorFrete_KeyUp(object sender, KeyEventArgs e)
        {
            txtValorUnidade.Text = EstoqueMateriaPrima.CalculaValorUnitario(txtQuantidade.Text, txtQuantoFaz.Text, txtValorPago.Text, txtValorFrete.Text);
        }

        private void TxtQuantoFaz_KeyUp(object sender, KeyEventArgs e)
        {
            txtValorUnidade.Text = EstoqueMateriaPrima.CalculaValorUnitario(txtQuantidade.Text, txtQuantoFaz.Text, txtValorPago.Text, txtValorFrete.Text);
        }

        private void TxtQuantidade_KeyUp(object sender, KeyEventArgs e)
        {
            txtValorUnidade.Text = EstoqueMateriaPrima.CalculaValorUnitario(txtQuantidade.Text, txtQuantoFaz.Text, txtValorPago.Text, txtValorFrete.Text);
        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
