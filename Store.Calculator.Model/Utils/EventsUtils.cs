using System.Text.RegularExpressions;

namespace Store.Calculator.Model.Utils
{
    public class EventsUtils
    {
        public static bool ValidaDecimal(string texto, string digito)
        {
            if (texto.Length == 0 && digito.Contains(","))
                return true;

            if (texto.Contains(","))
            {
                Regex regex = new Regex("[0-9]");
                if (texto.Split(',')[1].Length > 1)
                    return true;
                return !regex.IsMatch(digito);
            }
            else
            {
                Regex regex = new Regex("[0-9,]");
                return !regex.IsMatch(digito);
            }
        }

        public static bool ValidaNumero(string texto, string digito)
        {
            Regex regex = new Regex("[0-9]");
            return !regex.IsMatch(digito);
        }

        public static bool ValidaTempo(string texto, string digito)
        {
            Regex regex = new Regex("^(?:(?:[0-9]?[0-9]?)(?::(?:[0-5][0-9]?)?)?)?$");
            return !regex.IsMatch(texto+digito);
        }

        public static bool ValidaPercentual(string texto, string digito)
        {
            Regex regex = new Regex("^(100|[0-9]?[0-9]?)?$");
            return !regex.IsMatch(texto + digito);
        }
    }
}
