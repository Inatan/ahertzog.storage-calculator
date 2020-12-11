using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using store_calculator.ViewModels;

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
            e.Handled = CadastroMaterialVM.ValidaDecimal(txtValorFrete.Text, e.Text);
        }

        private void DecimalValidationValorPago(object sender, TextCompositionEventArgs e)
        {
            e.Handled = CadastroMaterialVM.ValidaDecimal(txtValorPago.Text, e.Text);
        }

        private void NumeroValidationQuantidade(object sender, TextCompositionEventArgs e)
        {
            e.Handled = CadastroMaterialVM.ValidaNumero(txtQuantidade.Text, e.Text);
        }

        private void NumeroValidationQuantoFaz(object sender, TextCompositionEventArgs e)
        {
            e.Handled = CadastroMaterialVM.ValidaNumero(txtQuantoFaz.Text, e.Text);
        }


        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TextInputValorFrete(object sender, TextCompositionEventArgs e)
        {
            txtValorUnidade.Text = CadastroMaterialVM.CalculaValorUnitario(txtQuantidade.Text, txtQuantoFaz.Text, txtValorPago.Text, txtValorFrete.Text);
        }

        private void TxtValorFrete_KeyUp(object sender, KeyEventArgs e)
        {
            txtValorUnidade.Text = CadastroMaterialVM.CalculaValorUnitario(txtQuantidade.Text, txtQuantoFaz.Text, txtValorPago.Text, txtValorFrete.Text);
        }

        private void TxtQuantoFaz_KeyUp(object sender, KeyEventArgs e)
        {
            txtValorUnidade.Text = CadastroMaterialVM.CalculaValorUnitario(txtQuantidade.Text, txtQuantoFaz.Text, txtValorPago.Text, txtValorFrete.Text);
        }

        private void TxtQuantidade_KeyUp(object sender, KeyEventArgs e)
        {
            txtValorUnidade.Text = CadastroMaterialVM.CalculaValorUnitario(txtQuantidade.Text, txtQuantoFaz.Text, txtValorPago.Text, txtValorFrete.Text);
        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
