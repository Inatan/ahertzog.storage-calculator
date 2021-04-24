using System;
using System.Collections.Generic;
using System.Linq;

namespace Store.Calculator.Domain
{
    public class OrcamentoCalculado
    {
        public OrcamentoCalculado(TimeSpan tempoEstimado, IList<ConsumoMaterial> materiasPrima, decimal valorHora,decimal lucro)
        {
            this.TempoEstimado = tempoEstimado;
            MateriasPrima = materiasPrima;
            ValorHora = valorHora;
            Lucro = lucro;
        }

        public TimeSpan TempoEstimado { get; }

        public decimal Lucro { get; }
        public decimal ValorHora { get; }
        public IList<ConsumoMaterial> MateriasPrima { get; }

        public decimal Total {
            get
            {
                return  (MateriasPrima.Sum(m => m.Total) + ((decimal)TempoEstimado.TotalHours * ValorHora)) * (1 + Lucro/100);
            }
        }

    }
}
