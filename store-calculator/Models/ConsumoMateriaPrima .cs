using System;

namespace store_calculator.Models
{
    public class ConsumoMateriaPrima : MateriaPrima
    {
        public int Quantidade { get; set; }
        public int QuantoFaz { get; set; }
        public float ValorPago { get; set; }
        public int PecasUtilizadas { get; set; }
        public double Total { get; }

        public ConsumoMateriaPrima()
        {
            Nome = String.Empty;
            Medida = 0;
            ValorUnitario = 0.00f;
            Quantidade = 0;
            QuantoFaz = 0;
            ValorPago = 0.00f;
            PecasUtilizadas = 0;
        }

        public ConsumoMateriaPrima(string nome, int medida, float valorUnitario, 
                                    int quantidade, int quantoFaz, float valorPago, int pecasUtilizadas)
        {
            Nome = nome;
            Medida = medida;
            ValorUnitario = valorUnitario;
            Quantidade = quantidade;
            QuantoFaz = quantoFaz;
            ValorPago = valorPago;
            PecasUtilizadas = pecasUtilizadas;
        }
    }
}
