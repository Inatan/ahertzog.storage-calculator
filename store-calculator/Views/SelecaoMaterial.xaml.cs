using Store.Calculator.Model;
using Store.Calculator.Model.Utils;
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
        private readonly ICadastroMaterialHandler _handler;

        public ConsumoMaterial consumo {get; private set;}

        public SelecaoMaterial(ICadastroMaterialHandler handler)
        {
            _handler = handler;
            InitializeComponent();
            var materiais = handler.Listar();
            dataGridClientes.ItemsSource = materiais;
            
        }

        private void txtQuantidade_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = EventsUtils.ValidaNumero(txtQuantidade.Text, e.Text);
        }

        private void btnSelecionar_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridClientes.SelectedItem == null)
                AppUtils.MensagemErro("Falha nenhum material foi seleciona");
            else if (string.IsNullOrEmpty(txtQuantidade.Text) ||  Convert.ToInt32(txtQuantidade.Text) < 1)
                AppUtils.MensagemErro("Falha nenhum a quantidade selecionada deve ser maior que 0");
            else
            {
                Material material = (Material)dataGridClientes.SelectedItem;
                consumo = new ConsumoMaterial(material, Convert.ToDecimal(txtQuantidade.Text, AppUtils.cultureInfo) );
                DialogResult = true;
                Close();
            }

        }
    }
}
