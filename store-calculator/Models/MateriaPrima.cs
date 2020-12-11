using System;

namespace Store.Calculator.Model.App.Models
{
    public class MateriaPrima
    {
        public string Nome { get; set; }
        

        public MateriaPrima()
        {
            this.Nome = String.Empty;

        }

        public MateriaPrima(string nome)
        {
            this.Nome = nome;
        }
    }
}
