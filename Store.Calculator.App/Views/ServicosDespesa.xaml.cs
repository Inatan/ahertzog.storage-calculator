﻿using Store.Calculator.Domain;
using Store.Calculator.Domain.Utils;
using Store.Calculator.Services;
using System;
using System.Collections.Generic;
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
            try
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
            catch (Exception ex)
            {
                AppUtils.MensagemErro($"Erro ao adicionar dados: {ex.Message}");
            }
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    AppUtils.MensagemErro($"Erro ao salvar dados: {ex.InnerException.Message}");
                else
                    AppUtils.MensagemErro($"Erro ao salvar dados: {ex.Message}");
               
            }
}

        private void btnDeletar_Click(object sender, RoutedEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                AppUtils.MensagemErro($"Erro ao deletar a linha: {ex.Message}");
            }
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
            try
            {
                using (System.Windows.Forms.OpenFileDialog fileDialog = new System.Windows.Forms.OpenFileDialog())
                {
                    fileDialog.InitialDirectory = "c:\\";
                    fileDialog.Filter = "txt files (*.csv)|*.csv";
                    fileDialog.FilterIndex = 2;
                    fileDialog.RestoreDirectory = true;
                    var result = fileDialog.ShowDialog();
                    switch (result)
                    {
                        case System.Windows.Forms.DialogResult.OK:
                            Importador importador = new Importador();
                            List<ValorServico> valoresServicos = importador.LeValorServico(fileDialog.FileName);
                        
                            dataGridServicos.ItemsSource = valoresServicos;
                            dataGridServicos.Items.Refresh();
                            _handler.valorServicoHandler.LimpaTable();
                            _handler.valorServicoHandler.CadastraLista(valoresServicos);
                            MessageBox.Show("Dados dos serviços atualizados com sucesso", "Importação", MessageBoxButton.OK, MessageBoxImage.Information);
                            break;
                        case System.Windows.Forms.DialogResult.Cancel:
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    AppUtils.MensagemErro($"Erro ao importar dados: {ex.InnerException.Message}");
                else
                    AppUtils.MensagemErro($"Erro ao importar dados: {ex.Message}");
            }
        }

        private void dataGridServicos_CellEditEnding(object sender, System.Windows.Controls.DataGridCellEditEndingEventArgs e)
        {
            dataGridServicos.Dispatcher.BeginInvoke(new Action(() => AtualizaDados()), System.Windows.Threading.DispatcherPriority.Background);
        }

        private void AtualizaDados()
        {
            try
            {
                dataGridServicos.Items.Refresh();
            }
            catch (Exception ex)
            {
                AppUtils.MensagemErro($"Erro ao editar célula: {ex.Message}");
            }
        }
    }
}
