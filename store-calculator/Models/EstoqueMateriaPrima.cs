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
        public decimal TotalFinal { get { return ValorPago + ValorFrete; } }
        public decimal TotalUnitarioFinal { get { return Math.Round((TotalFinal / QuantoFaz), 2); } }

        public EstoqueMateriaPrima()
        {
            Nome = String.Empty;
            Medida = 0;
            ValorUnitario = 0.00M;
            Quantidade = 0;
            QuantoFaz = 0;
            ValorPago = 0.00M;
        }

        public EstoqueMateriaPrima(string nome, int medida, decimal valorUnitario, 
                                    int quantidade, int quantoFaz, decimal valorPago, int pecasUtilizadas)
        {
            Nome = nome;
            Medida = medida;
            ValorUnitario = valorUnitario;
            Quantidade = quantidade;
            QuantoFaz = quantoFaz;
            ValorPago = valorPago;
        }
    }
}
