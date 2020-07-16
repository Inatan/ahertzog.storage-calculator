using System;

namespace store_calculator.Models
{
    public class MateriaPrima
    {
        public string Nome { get; set; }
        public int Medida { get; set; }
        public decimal ValorUnitario { get; set; }

        public MateriaPrima()
        {
            this.Nome = String.Empty;
            this.Medida = 0;
            this.ValorUnitario = 0.00M;
        }

        public MateriaPrima(string nome, int medida, decimal valorUnitario)
        {
            this.Nome = nome;
            this.Medida = medida;
            this.ValorUnitario = valorUnitario;
        }
    }
}
