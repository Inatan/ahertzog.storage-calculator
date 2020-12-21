using Store.Calculator.Model;
using Store.Calculator.Model.Utils;
using Store.Calculator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Store.Calculator.App.Views
{
    /// <summary>
    /// Lógica interna para Materiais.xaml
    /// </summary>
    public partial class Materiais : Window
    {
        private readonly ServicesControl _handler;

        private List<Material> materials;

        private List<Material> deletados;

        public Materiais(ServicesControl handler)
        {
            _handler = handler;
            InitializeComponent();
            materials = handler.materialHandler.Listar();
            dataGridServicos.ItemsSource = materials;
            deletados = new List<Material>();
        }

        private void btnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            CadastroMateriaPrima tela = new CadastroMateriaPrima(_handler);
            if (tela.ShowDialog() == true)
            {
                materials = _handler.materialHandler.Listar();
                dataGridServicos.ItemsSource = materials;
                dataGridServicos.Items.Refresh();
            }
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
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

        private void btnDeletar_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridServicos.SelectedItem != null)
            {
                deletados.Add(dataGridServicos.SelectedItem as Material);
                materials.RemoveAt(dataGridServicos.SelectedIndex);
                dataGridServicos.ItemsSource = materials;
                dataGridServicos.Items.Refresh();
            }
            else
                AppUtils.MensagemErro("Nome e valor são obrigatórios para o cadastro");

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
            using (System.Windows.Forms.OpenFileDialog fileDialog = new System.Windows.Forms.OpenFileDialog())
            {
                fileDialog.InitialDirectory = "c:\\";
                fileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                fileDialog.FilterIndex = 2;
                fileDialog.RestoreDirectory = true;
                var result = fileDialog.ShowDialog();
                switch (result)
                {
                    case System.Windows.Forms.DialogResult.OK:
                        Importador importador = new Importador();
                        List<Material> materials = importador.LeMateriais(fileDialog.FileName);
                        _handler.materialHandler.LimpaTable();
                        _handler.materialHandler.CadastraLista(materials);
                        dataGridServicos.ItemsSource = materials;
                        dataGridServicos.Items.Refresh();
                        MessageBox.Show("Dados dos materiais foram atualizados com sucesso", "Importação", MessageBoxButton.OK, MessageBoxImage.Information);
                        break;
                    case System.Windows.Forms.DialogResult.Cancel:
                    default:
                        break;
                }
            }
        }
    }
}
