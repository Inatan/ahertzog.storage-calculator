using System;
using System.Collections.Generic;
using System.Linq;

namespace Store.Calculator.Model
{
    public class OrcamentoCalculado
    {
        public OrcamentoCalculado(TimeSpan tempoEstimado, IList<ConsumoMaterial> materiasPrima, decimal valorHora)
        {
            this.TempoEstimado = tempoEstimado;
            MateriasPrima = materiasPrima;
            ValorHora = valorHora;
        }

        public TimeSpan TempoEstimado { get; }

        public decimal ValorHora { get; }
        public IList<ConsumoMaterial> MateriasPrima { get; set; }

        public decimal Total {
            get
            {
                return  MateriasPrima.Sum(m => m.Total) + ((decimal)TempoEstimado.TotalHours * ValorHora);
            }
        }

    }
}
