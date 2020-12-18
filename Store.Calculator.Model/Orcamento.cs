using System;
using System.Collections.Generic;
using System.Linq;

namespace Store.Calculator.Model
{
    public class Orcamento
    {
        public string Nome { get; set; }
        public IList<ConsumoMaterial> MateriasPrima { get; set; }
        //public Decimal ValorTotal { get { return (Decimal)MateriasPrima.Select(m => m.Total).ToList().Sum(); } }

        public Orcamento()
        {
            Nome = String.Empty;
            MateriasPrima = new List<ConsumoMaterial>();
        }

        public Orcamento(string nome, IList<ConsumoMaterial> materiasPrima)
        {
            Nome = nome;
            MateriasPrima = materiasPrima;
        }
    }
}
