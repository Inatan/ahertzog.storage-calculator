using store_calculator.Models;
using System;
using System.Text.RegularExpressions;

namespace store_calculator.ViewModels
{
    public class CadastroMaterialVM
    {
        public static bool ValidaDecimal(string texto, string digito)
        {

            if (texto.Contains(","))
            {
                if (texto.Split(',')[1].Length > 1)
                    return true;
                Regex regex = new Regex("[0-9]");
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

        public static string CalculaValorUnitario(string quantidade,string quantosFaz, string valorPago, string valorFrete)
        {
            string valorUnitario = string.Empty;
            if(!string.IsNullOrEmpty(quantidade) && !string.IsNullOrEmpty(quantosFaz) && !string.IsNullOrEmpty(valorPago) && !string.IsNullOrEmpty(valorFrete))
            {
                int qtd = Convert.ToInt32(quantidade), qtFaz = Convert.ToInt32(quantosFaz);
                decimal pago = Convert.ToDecimal(valorPago), frete = Convert.ToDecimal(valorFrete);
                valorUnitario = Math.Round((((pago/qtd) + frete)/qtFaz),2).ToString().Replace(".",",");
            }

            return valorUnitario;
        }

        public static void SalvarMaterial(string nome, string unidade,string quantidade, string quantosFaz, string valorPago, string valorFrete)
        {
            EstoqueMateriaPrima estoque = new EstoqueMateriaPrima(nome, unidade, Convert.ToInt32(quantidade), Convert.ToInt32(quantosFaz), Convert.ToDecimal(valorFrete), Convert.ToDecimal(valorPago), 0);
        }
    }
}
