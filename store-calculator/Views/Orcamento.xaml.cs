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
            atualizaTabela();
        }

        private void atualizaTabela()
        {
            for (int i = 0; i < 5; i++)
            {
                TableRow tableRow = new TableRow();
                TableRowValor.Rows.Add(tableRow);
                if(TableRowValor.Rows.Count % 2 == 1)
                    tableRow.Background = Brushes.LightGray;

                tableRow.Cells.Add(new TableCell(new Paragraph(new Run("2004 Sales Project"))));
                tableRow.Cells.Add(new TableCell(new Paragraph(new Run("2004 Sales Project"))));
                tableRow.Cells.Add(new TableCell(new Paragraph(new Run("2004 Sales Project"))));
                tableRow.Cells.Add(new TableCell(new Paragraph(new Run("2004 Sales Project"))));
            }
        }
    }
}
