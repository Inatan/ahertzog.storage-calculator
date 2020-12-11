using Store.Calculator.Model.Utils;
using System;

namespace store_calculator.ViewModels
{
    public class CadastroMaterialVM
    {
        public static bool ValidaDecimal(string texto, string digito)
        {
            return EventsUtils.ValidaDecimal(texto, digito);
        }

        public static bool ValidaNumero(string texto, string digito)
        {
            return EventsUtils.ValidaNumero(texto, digito);
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
