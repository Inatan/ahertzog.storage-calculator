﻿using Store.Calculator.Model;
using Store.Calculator.Model.Utils;
using Store.Calculator.Services;
using System;
using System.Linq;
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
        private readonly ServicesControl _handler;

        private decimal totalPayment;

        public Orcamento(ServicesControl handler)
        {
            _handler = handler;
            totalPayment = 0.00M;
            InitializeComponent();
            txtValorHora.Text = AppUtils.FormatCurrency(handler.valorServicoHandler.Listar().Sum(s => s.ValorPorHora));
        }

        private void AtualizaTabela(ConsumoMaterial consumo)
        {
            TableRow tableRow = new TableRow();
            if (TableRowValor.Rows.Count > 1)
                TableRowValor.Rows.RemoveAt(TableRowValor.Rows.Count - 1);
            TableRowValor.Rows.Add(tableRow);
            if (TableRowValor.Rows.Count % 2 == 1)
                tableRow.Background = Brushes.LightGray;

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
            }
        }

        private void txtTempo_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = EventsUtils.ValidaTempo(txtTempo.Text, e.Text);
        }
    }
}
