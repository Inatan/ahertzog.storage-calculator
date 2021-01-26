using Store.Calculator.Model.Utils;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Calculator.Model
{
    [Table("ValorServico")]
    public class ValorServico
    {
        public ValorServico(string nome, decimal valor)
        {
            Id = 0;
            Nome = nome;
            Valor = valor;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }

        public decimal ValorPorDia 
        { 
            get
            {
                return Math.Round(Valor/Constants.DIAS_TRABALHADOS_POR_MES,2);
            } 
        }

        public decimal ValorPorHora
        {
            get
            {
                return Math.Round(Valor/Constants.HORAS_TRABALHADAS_POR_MES,2);
            }
        }

    }
}
