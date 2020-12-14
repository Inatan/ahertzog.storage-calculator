using Store.Calculator.Model;
using System;

namespace store_calculator.ViewModels
{
    public class CadastroMaterialVM
    {
        public static void SalvarMaterial(string nome, string unidade,string quantidade, string quantosFaz, string valorPago, string valorFrete)
        {
            EstoqueMateriaPrima estoque = new EstoqueMateriaPrima(nome, unidade, Convert.ToInt32(quantidade), Convert.ToInt32(quantosFaz), Convert.ToDecimal(valorFrete), Convert.ToDecimal(valorPago), 0);
        }
    }
}
