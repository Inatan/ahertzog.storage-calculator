using System;
using System.Windows;
using System.Windows.Input;
using Store.Calculator.Domain;
using Store.Calculator.Domain.Utils;
using Store.Calculator.Services;

namespace Store.Calculator.App.Views
{
    /// <summary>
    /// Lógica interna para CadastroMateriaPrima.xaml
    /// </summary>
    public partial class CadastroMateriaPrima : Window
    {
        private readonly ServicesControl _handler;

        public CadastroMateriaPrima(ServicesControl handler)
        {
            _handler = handler;
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
            txtValorUnidade.Text = Domain.Material.CalculaValorUnitario(txtQuantidade.Text, txtQuantoFaz.Text, txtValorPago.Text, txtValorFrete.Text);
        }

        private void TxtValorFrete_KeyUp(object sender, KeyEventArgs e)
        {
            txtValorUnidade.Text = Domain.Material.CalculaValorUnitario(txtQuantidade.Text, txtQuantoFaz.Text, txtValorPago.Text, txtValorFrete.Text);
        }

        private void TxtQuantoFaz_KeyUp(object sender, KeyEventArgs e)
        {
            txtValorUnidade.Text = Domain.Material.CalculaValorUnitario(txtQuantidade.Text, txtQuantoFaz.Text, txtValorPago.Text, txtValorFrete.Text);
        }

        private void TxtQuantidade_KeyUp(object sender, KeyEventArgs e)
        {
            txtValorUnidade.Text = Domain.Material.CalculaValorUnitario(txtQuantidade.Text, txtQuantoFaz.Text, txtValorPago.Text, txtValorFrete.Text);
        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {
            Domain.Material estoque = 
                new Material(
                    txtNome.Text,
                    txtUnidadeMedida.Text,
                    Convert.ToInt32(txtQuantidade.Text),
                    Convert.ToInt32(txtQuantoFaz.Text),
                    Convert.ToDecimal(txtValorFrete.Text),
                    Convert.ToDecimal(txtValorPago.Text)
                );
            _handler.materialHandler.Cadastra(estoque);
            DialogResult = true;
            MessageBox.Show("Produto Cadastrado com Sucesso!", "Sucesso", MessageBoxButton.OK,MessageBoxImage.Asterisk);
            this.Close();
        }
    }
}
