using System;

namespace Store.Calculator.Model.App.Models
{ 
    public class ConsumoMateriaPrima : MateriaPrima
    {
        public int Quantidade { get; set; }
        public int QuantoFaz { get; set; }
        public decimal ValorPago { get; set; }
        public int PecasUtilizadas { get; set; }
        public double Total { get; }

        public ConsumoMateriaPrima()
        {
            Nome = String.Empty;
            Quantidade = 0;
            QuantoFaz = 0;
            ValorPago = 0.00M;
            PecasUtilizadas = 0;
        }

        public ConsumoMateriaPrima(string nome, int medida, decimal valorUnitario, 
                                    int quantidade, int quantoFaz, decimal valorPago, int pecasUtilizadas)
        {
            Nome = nome;
            Quantidade = quantidade;
            QuantoFaz = quantoFaz;
            ValorPago = valorPago;
            PecasUtilizadas = pecasUtilizadas;
        }
    }
}
