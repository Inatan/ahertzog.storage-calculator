using Store.Calculator.Services.Handlers;
using System.Windows;

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
    }
}
