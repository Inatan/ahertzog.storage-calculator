using System;

namespace store_calculator.Models
{
    public class EstoqueMateriaPrima : MateriaPrima
    {
        public string Unidade { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorPago { get; set; }
        public decimal ValorFrete { get; set; }
        public int QuantoFaz { get; set; }
        public string Medida { get { return Quantidade.ToString() + " " + Unidade; } }
        public decimal TotalFinal { get { return Math.Round((ValorPago + ValorFrete)/Quantidade,2); } }
        public decimal TotalUnitarioFinal { get { return Math.Round((TotalFinal / QuantoFaz), 2); } }

        public EstoqueMateriaPrima()
        {
            Nome = String.Empty;
            Quantidade = 0;
            Unidade = " UN.";
            QuantoFaz = 0;
            ValorPago = 0.00M;
            ValorFrete = 0.00M;
        }

        public EstoqueMateriaPrima(string nome, string unidade,int quantidade, 
                                int quantoFaz, decimal valorFrete, decimal valorPago, int pecasUtilizadas)
        {
            Nome = nome;
            Unidade = unidade;
            Quantidade = quantidade;
            QuantoFaz = quantoFaz;
            ValorPago = valorPago;
            ValorFrete = valorFrete;
        }
    }
}
