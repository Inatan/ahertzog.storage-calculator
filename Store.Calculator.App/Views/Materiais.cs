using Store.Calculator.Domain;
using Store.Calculator.Domain.Utils;
using Store.Calculator.Services;
using System;
using System.Collections.Generic;
using System.Windows;

namespace Store.Calculator.App.Views
{
    /// <summary>
    /// Lógica interna para Materiais.xaml
    /// </summary>
    public partial class Materiais : Window
    {
        private readonly ServicesControl _handler;

        private List<Material> materiais;

        private List<Material> deletados;

        public Materiais(ServicesControl handler)
        {
            _handler = handler;
            InitializeComponent();
            materiais = handler.materialHandler.Listar();
            dataGridServicos.ItemsSource = materiais;
            deletados = new List<Material>();
        }

        private void btnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CadastroMateriaPrima tela = new CadastroMateriaPrima(_handler);
                if (tela.ShowDialog() == true)
                {
                    materiais = _handler.materialHandler.Listar();
                    dataGridServicos.ItemsSource = materiais;
                    dataGridServicos.Items.Refresh();
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
                foreach (Material item in dataGridServicos.Items)
                {
                    _handler.materialHandler.Altera(item);
                }
                foreach (Material item in deletados)
                {
                    _handler.materialHandler.Deleta(item);
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
                if (dataGridServicos.SelectedItem != null)
                {
                    deletados.Add(dataGridServicos.SelectedItem as Material);
                    materiais.RemoveAt(dataGridServicos.SelectedIndex);
                    dataGridServicos.ItemsSource = materiais;
                    dataGridServicos.Items.Refresh();
                }
                else
                    AppUtils.MensagemErro("Nome e valor são obrigatórios para o cadastro");
            }
            catch (Exception ex)
            {
                AppUtils.MensagemErro($"Erro ao deletar linha: {ex.Message}");
            }
        }

        private void txtPesquisa_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            dataGridServicos.Items.Filter = (obj) =>
            {
                Material material = obj as Material;
                return material.Nome.ToLower().Contains(txtPesquisa.Text.Trim().ToLower());
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
                            materiais = importador.LeMateriais(fileDialog.FileName);
                            dataGridServicos.ItemsSource = materiais;
                            dataGridServicos.Items.Refresh();
                            _handler.materialHandler.LimpaTable();
                            _handler.materialHandler.CadastraLista(materiais);
                            MessageBox.Show("Dados dos materiais foram atualizados com sucesso", "Importação", MessageBoxButton.OK, MessageBoxImage.Information);
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
