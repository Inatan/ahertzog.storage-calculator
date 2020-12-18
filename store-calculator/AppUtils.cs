using System.Windows;

namespace Store.Calculator.App
{
    public class AppUtils
    {
        public static void MensagemErro(string message, string title = "Erro")
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
