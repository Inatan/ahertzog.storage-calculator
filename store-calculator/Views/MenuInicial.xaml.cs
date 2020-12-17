﻿using Store.Calculator.Infrastructure;
using System.Windows;

namespace Store.Calculator.App.Views
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MenuInicial : Window
    {

        IRepositoryMaterial _repo;
        public MenuInicial(IRepositoryMaterial repo)
        {
            _repo = repo;
            InitializeComponent();
        }

        private void BtnCadastro_Click(object sender, RoutedEventArgs e)
        {
            _repo.ObtemMaterialEstoque();
            CadastroMateriaPrima tela = new CadastroMateriaPrima(_repo);
            tela.ShowDialog();
        }

        private void BtnFechar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
