using System;
using System.Globalization;
using System.Threading;
using System.Windows;

namespace Store.Calculator.App
{
    public class AppUtils
    {
        public static CultureInfo cultureInfo
        {
            get
            {
                CultureInfo cultureInfo = new CultureInfo("pt-BR");
                cultureInfo.NumberFormat.CurrencySymbol = "";
                Thread.CurrentThread.CurrentCulture = cultureInfo;
                return cultureInfo;
            }
        }

        public static string FormatCurrency(decimal value)
        {
            return "R$ " + String.Format(cultureInfo, "{0:C}", value);
        }

        public static void MensagemErro(string message, string title = "Erro")
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
