using System;
using System.Collections.Generic;
using System.Linq;

namespace Store.Calculator.Model
{
    public class Orcamento
    {
        public Orcamento(TimeSpan tempoEstimado, IList<ConsumoMaterial> materiasPrima)
        {
            this.TempoEstimado = tempoEstimado;
            MateriasPrima = materiasPrima;
        }

        public TimeSpan TempoEstimado { get; set; }
        public IList<ConsumoMaterial> MateriasPrima { get; set; }

        public decimal Total {
            get
            {
                return  MateriasPrima.Sum(m => m.Total) + ((decimal)TempoEstimado.TotalHours * BuscaValorHora());
            }
        }


        private decimal BuscaValorHora()
        {
            return 16.00M;
        }
    }
}
