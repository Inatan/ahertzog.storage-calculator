using Store.Calculator.Model;
using Store.Calculator.Model.Utils;
using Store.Calculator.Services.Handlers;
using System;
using System.Data;
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
        public string Nome { get; private set; }
        public string Unidade { get; private set; }
        public string Preco { get; private set; }
        public string Quantidade { get; private set; }
        public string Total { get; private set; }


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
                EstoqueMateriaPrima material = (EstoqueMateriaPrima)dataGridClientes.SelectedItem;
                Nome = material.Nome;
                Unidade = material.Unidade;
                Preco = material.TotalFinal.ToString();
                Quantidade = txtQuantidade.Text;
                Total = (material.TotalFinal * Convert.ToDecimal(txtQuantidade.Text.Replace(",", "."))).ToString();
                DialogResult = true;
                Close();
            }

        }
    }
}
