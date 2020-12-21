using Store.Calculator.Model;
using Store.Calculator.Model.Utils;
using Store.Calculator.Services;
using Store.Calculator.Services.Handlers;
using System;
using System.Windows;
using System.Windows.Input;

namespace Store.Calculator.App.Views
{
    /// <summary>
    /// Lógica interna para SelecaoMaterial.xaml
    /// </summary>
    public partial class SelecaoMaterial : Window
    {
        private readonly ServicesControl _handler;
        public ConsumoMaterial consumo {get; private set;}
        
        public SelecaoMaterial(ServicesControl handler)
        {
            _handler = handler;
            InitializeComponent();
            var materiais = handler.materialHandler.Listar();
            dataGridProdutos.ItemsSource = materiais;
        }

        private void txtQuantidade_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = EventsUtils.ValidaNumero(txtQuantidade.Text, e.Text);
        }

        private void btnSelecionar_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridProdutos.SelectedItem == null)
                AppUtils.MensagemErro("Falha nenhum material foi seleciona");
            else if (string.IsNullOrEmpty(txtQuantidade.Text) ||  Convert.ToInt32(txtQuantidade.Text) < 1)
                AppUtils.MensagemErro("Falha nenhum a quantidade selecionada deve ser maior que 0");
            else
            {
                Material material = (Material)dataGridProdutos.SelectedItem;
                consumo = new ConsumoMaterial(material, Convert.ToDecimal(txtQuantidade.Text, AppUtils.cultureInfo) );
                DialogResult = true;
                Close();
            }
        }

        private void txtPesquisa_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            dataGridProdutos.Items.Filter = (obj) =>
            {
                Material material = obj as Material;
                return material.Nome.ToLower().Contains(txtPesquisa.Text.Trim().ToLower());
            };
        }
    }
}
