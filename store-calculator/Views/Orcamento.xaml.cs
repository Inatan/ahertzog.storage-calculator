using Store.Calculator.Services.Handlers;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace Store.Calculator.App.Views
{
    /// <summary>
    /// Lógica interna para Orcamento.xaml
    /// </summary>
    public partial class Orcamento : Window
    {
        private readonly ICadastroMaterialHandler _handler;

        public Orcamento(ICadastroMaterialHandler handler)
        {
            _handler = handler;
            InitializeComponent();
        }

        private void AtualizaTabela(string nome, string unidade, string preco, string quantidade, string total )
        {
            TableRow tableRow = new TableRow();
            TableRowValor.Rows.Add(tableRow);
            if(TableRowValor.Rows.Count % 2 == 1)
                tableRow.Background = Brushes.LightGray;

            tableRow.Cells.Add(new TableCell(new Paragraph(new Run(nome))));
            tableRow.Cells.Add(new TableCell(new Paragraph(new Run(unidade))));
            tableRow.Cells.Add(new TableCell(new Paragraph(new Run(preco))));
            tableRow.Cells.Add(new TableCell(new Paragraph(new Run(quantidade))));
            tableRow.Cells.Add(new TableCell(new Paragraph(new Run(total))));
        }

        private void BtnAdicionarProduto_Click(object sender, RoutedEventArgs e)
        {
            SelecaoMaterial tela = new SelecaoMaterial(_handler);
            if(tela.ShowDialog() == true)
            {
                AtualizaTabela(tela.Nome, tela.Unidade,tela.Preco,tela.Quantidade,tela.Total);
            }
        }
    }
}
