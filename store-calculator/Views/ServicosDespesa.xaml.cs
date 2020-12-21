using Store.Calculator.Model;
using Store.Calculator.Model.Utils;
using Store.Calculator.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows;

namespace Store.Calculator.App.Views
{
    /// <summary>
    /// Lógica interna para ServicosDespesa.xaml
    /// </summary>
    public partial class ServicosDespesa : Window
    {
        private readonly ServicesControl _handler;



        private List<ValorServico> servicos;
        
        private List<ValorServico> deletados;

        public ServicosDespesa(ServicesControl handler)
        {
            _handler = handler;
            InitializeComponent();
            servicos = handler.valorServicoHandler.Listar();
            dataGridServicos.ItemsSource = servicos;
            deletados = new List<ValorServico>();
        }

        private void btnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNome.Text) || string.IsNullOrEmpty(txtValor.Text))
                AppUtils.MensagemErro("Nome e valor são obrigatórios para o cadastro");
            else
            {
                ValorServico valorServico = new ValorServico(txtNome.Text, Convert.ToDecimal(txtValor.Text,AppUtils.cultureInfo));
                servicos.Add(valorServico);
                dataGridServicos.ItemsSource = servicos;
                dataGridServicos.Items.Refresh();
                txtNome.Clear();
                txtValor.Clear();
            }
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {

            foreach (ValorServico item in dataGridServicos.Items)
            {
                if (item.Id > 0)
                    _handler.valorServicoHandler.Altera(item);
                else
                    _handler.valorServicoHandler.Cadastra(item);
            }
            foreach (ValorServico item in deletados)
            {
                _handler.valorServicoHandler.Deleta(item);
            }

            if (MessageBox.Show("Alterações foram salvas com sucesso", "Salvar", MessageBoxButton.OK, MessageBoxImage.Information) == MessageBoxResult.OK)
                this.Close();
        }

        private void btnDeletar_Click(object sender, RoutedEventArgs e)
        {
            if(dataGridServicos.SelectedItem != null)
            {
                deletados.Add(dataGridServicos.SelectedItem as ValorServico);
                servicos.RemoveAt(dataGridServicos.SelectedIndex);
                dataGridServicos.ItemsSource = servicos;
                dataGridServicos.Items.Refresh();
            }
            else
                AppUtils.MensagemErro("Nome e valor são obrigatórios para o cadastro");

        }

        private void txtValor_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = EventsUtils.ValidaDecimal(txtValor.Text, e.Text);
        }

        private void txtPesquisa_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            dataGridServicos.Items.Filter = (obj) =>
            {
                ValorServico servico = obj as ValorServico;
                return servico.Nome.ToLower().Contains(txtPesquisa.Text.Trim().ToLower());
            };
        }

        private void btnImportar_Click(object sender, RoutedEventArgs e)
        {
            using (System.Windows.Forms.OpenFileDialog fileDialog = new System.Windows.Forms.OpenFileDialog())
            {
                fileDialog.InitialDirectory = "c:\\";
                fileDialog.Filter = "txt files (*.csv)|*.csv";
                fileDialog.FilterIndex = 2;
                fileDialog.RestoreDirectory = true;
                var result = fileDialog.ShowDialog();
                List<ValorServico> valoresServicos = new List<ValorServico>();
                switch (result)
                {
                    case System.Windows.Forms.DialogResult.OK:
                        //var file = fileDialog.FileName;
                        using (StreamReader sr = new StreamReader(fileDialog.FileName))
                        {
                            string currentLine;
                            // currentLine will be null when the StreamReader reaches the end of file
                            while ((currentLine = sr.ReadLine()) != null)
                            {
                                // Search, case insensitive, if the currentLine contains the searched keyword
                                string[] linhaSeparada = currentLine.Split(';');
                                string nome = linhaSeparada[0];
                                decimal valor =  Decimal.Parse(linhaSeparada[1].Replace("R$","").Trim(),NumberStyles.Currency,AppUtils.cultureInfo);
                                valoresServicos.Add(new ValorServico(nome, valor));
                            }
                            dataGridServicos.ItemsSource = valoresServicos;
                            dataGridServicos.Items.Refresh();
                            // TODO: limpa banco
                            // atualiza banco
                            // Envia mensagem
                            // Fecha janela
                        }
                        break;
                    case System.Windows.Forms.DialogResult.Cancel:
                    default:
                        
                        break;
                }
            }
        }
    }
}
