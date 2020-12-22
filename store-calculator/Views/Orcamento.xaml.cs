using ceTe.DynamicPDF;
using Store.Calculator.Model;
using Store.Calculator.Model.Utils;
using Store.Calculator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Forms;

namespace Store.Calculator.App.Views
{
    /// <summary>
    /// Lógica interna para Orcamento.xaml
    /// </summary>
    public partial class Orcamento : Window
    {
        private readonly ServicesControl _handler;

        private decimal totalPayment;

        private List<ConsumoMaterial> Selecionados;

        public Orcamento(ServicesControl handler)
        {
            _handler = handler;
            totalPayment = 0.00M;
            InitializeComponent();
            txtValorHora.Text = AppUtils.FormatCurrency(handler.valorServicoHandler.Listar().Sum(s => s.ValorPorHora));
            Selecionados = new List<ConsumoMaterial>();
        }

        private void AtualizaTabela(ConsumoMaterial consumo)
        {
            TableRow tableRow = new TableRow();
            if (TableRowValor.Rows.Count > 1)
                TableRowValor.Rows.RemoveAt(TableRowValor.Rows.Count - 1);
            TableRowValor.Rows.Add(tableRow);
            if (TableRowValor.Rows.Count % 2 == 1)
                tableRow.Background = System.Windows.Media.Brushes.LightGray;

            tableRow.Cells.Add(new TableCell(new Paragraph(new Run(consumo.MaterialConsumido.Nome))));
            tableRow.Cells.Add(new TableCell(new Paragraph(new Run(consumo.MaterialConsumido.Unidade))));
            tableRow.Cells.Add(new TableCell(new Paragraph(new Run(AppUtils.FormatCurrency(consumo.MaterialConsumido.TotalUnitarioFinal)))));
            tableRow.Cells.Add(new TableCell(new Paragraph(new Run(consumo.Quantidade.ToString(AppUtils.cultureInfo)))));
            tableRow.Cells.Add(new TableCell(new Paragraph(new Run(AppUtils.FormatCurrency(consumo.Total)))));

            tableRow = new TableRow();
            decimal totalCel = Convert.ToDecimal(consumo.Total, AppUtils.cultureInfo);
            totalPayment += totalCel;

            string totalTable = $"Total: {AppUtils.FormatCurrency(totalPayment)}";
            Paragraph paragraphFooter = new Paragraph(new Run(totalTable));
            paragraphFooter.FontSize = 20;
            paragraphFooter.TextAlignment = TextAlignment.Right;
            paragraphFooter.FontWeight = FontWeights.Bold;
            TableCell tableCellFooter = new TableCell(paragraphFooter);
            tableCellFooter.ColumnSpan = 5;
            tableRow.Cells.Add(tableCellFooter);
            TableRowValor.Rows.Add(tableRow);
        }

        private void BtnAdicionarProduto_Click(object sender, RoutedEventArgs e)
        {
            SelecaoMaterial tela = new SelecaoMaterial(_handler);
            if(tela.ShowDialog() == true)
            {
                AtualizaTabela(tela.consumo);
                Selecionados.Add(tela.consumo);
            }
        }

        private void txtTempo_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = EventsUtils.ValidaTempo(txtTempo.Text, e.Text);
        }

        private void BtnGerarOrcamento_Click(object sender, RoutedEventArgs e)
        {
            string[] tempoSeparado = txtTempo.Text.Split(':');
            int horas = Convert.ToInt32(tempoSeparado[0]);
            int minutos = Convert.ToInt32(tempoSeparado[1]);
            OrcamentoCalculado orcamento = 
                new OrcamentoCalculado(
                    new TimeSpan(horas,minutos,0), 
                    Selecionados, 
                    Convert.ToDecimal(txtValorHora.Text.Replace("R$","").Trim(), AppUtils.cultureInfo),
                    Convert.ToDecimal(txtLucro.Text,AppUtils.cultureInfo)
                );
            AtualizaValorFinal(orcamento);
        }

        private void AtualizaValorFinal(OrcamentoCalculado orcamento)
        {
            TableRow tableRow = new TableRow();
            decimal valorFinal = Convert.ToDecimal(orcamento.Total, AppUtils.cultureInfo);

            string totalTable = $"Valor Final: {AppUtils.FormatCurrency(valorFinal)}";
            Paragraph paragraphFooter = new Paragraph(new Run(totalTable));
            paragraphFooter.FontSize = 30;
            paragraphFooter.TextAlignment = TextAlignment.Right;
            paragraphFooter.FontWeight = FontWeights.Bold;
            TableCell tableCellFooter = new TableCell(paragraphFooter);
            tableCellFooter.ColumnSpan = 5;
            tableRow.Cells.Add(tableCellFooter);
            TableRowValor.Rows.Add(tableRow);

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF document (*.pdf)|*.pdf";
            saveFileDialog.FileName = "Teste.pdf";
            DialogResult result = saveFileDialog.ShowDialog();
            PdfCreator pdfCreator = new PdfCreator();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                Document document = new Document();
                //Page page = new Page(PageSize.Letter, PageOrientation.Portrait, 54.0f);
                //document.Pages.Add(page);

                //string labelText = " Hello World...\nHellow again \n Hi everyone";
                //Label label = new Label(labelText, 0, 0, 504, 100, Font.Helvetica, 18, TextAlign.Center);
                //page.Elements.Add(label);
                PageInfo layoutPage = new PageInfo(PageSize.A4, PageOrientation.Portrait);
                Uri uri = new Uri(@"http://www.google.com");

                HtmlLayout html = new HtmlLayout(uri, layoutPage);

                html.Header.Center.Text = "%%PR%%%%SP%% of %%ST%%";
                html.Header.Center.HasPageNumbers = true;
                html.Header.Center.Width = 200;

                html.Footer.Center.Text = "%%PR%%%%SP(A)%% of %%ST(B)%%";
                html.Footer.Center.HasPageNumbers = true;
                html.Footer.Center.Width = 200;

                document = html.Layout();

                document.Draw(filePath);
            }
                
        }

        private void txtLucro_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = EventsUtils.ValidaPercentual(txtLucro.Text, e.Text);
        }
    }
}
