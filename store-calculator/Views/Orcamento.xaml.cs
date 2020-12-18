﻿using Store.Calculator.Services.Handlers;
using System;
using System.Globalization;
using System.Threading;
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

        private decimal totalPayment;

        public Orcamento(ICadastroMaterialHandler handler)
        {
            _handler = handler;
            totalPayment = 0.00M;
            InitializeComponent();
        }

        private void AtualizaTabela(string nome, string unidade, string preco, string quantidade, string total )
        {
            TableRow tableRow = new TableRow();
            if (TableRowValor.Rows.Count > 1)
                TableRowValor.Rows.RemoveAt(TableRowValor.Rows.Count - 1);
            TableRowValor.Rows.Add(tableRow);
            if(TableRowValor.Rows.Count % 2 == 1)
                tableRow.Background = Brushes.LightGray;

            tableRow.Cells.Add(new TableCell(new Paragraph(new Run(nome))));
            tableRow.Cells.Add(new TableCell(new Paragraph(new Run(unidade))));
            tableRow.Cells.Add(new TableCell(new Paragraph(new Run(preco))));
            tableRow.Cells.Add(new TableCell(new Paragraph(new Run(quantidade))));
            tableRow.Cells.Add(new TableCell(new Paragraph(new Run(total))));

            tableRow = new TableRow();
            decimal totalCel= Convert.ToDecimal(total, AppUtils.cultureInfo);
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
                AtualizaTabela(tela.Nome, tela.Unidade,tela.Preco,tela.Quantidade,tela.Total);
            }
        }
    }
}
