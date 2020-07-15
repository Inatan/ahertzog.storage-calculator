using System;

namespace store_calculator.Models
{
    public class MateriaPrima
    {
        public string Nome { get; set; }
        public int Medida { get; set; }
        public float ValorUnitario { get; set; }

        public MateriaPrima()
        {
            this.Nome = String.Empty;
            this.Medida = 0;
            this.ValorUnitario = 0.00f;
        }
    }
}
