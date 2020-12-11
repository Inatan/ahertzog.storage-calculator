using System;
using System.Collections.Generic;
using System.Linq;

namespace store_calculator.Models
{
    public class Material
    {
        public string Nome { get; set; }
        public IList<ConsumoMateriaPrima> MateriasPrima { get; set; }
        public Decimal ValorTotal { get { return (Decimal)MateriasPrima.Select(m => m.Total).ToList().Sum(); } }

        public Material()
        {
            Nome = String.Empty;
            MateriasPrima = new List<ConsumoMateriaPrima>();
        }

        public Material(string nome, IList<ConsumoMateriaPrima> materiasPrima)
        {
            Nome = nome;
            MateriasPrima = materiasPrima;
        }
    }
}
