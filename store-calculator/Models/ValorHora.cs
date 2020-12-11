using System;

namespace Store.Calculator.Model.App.Models
{
    public class ValorHora
    {
        public TimeSpan HoraFormatada { get; set; }
        public string Tempo { get
            {
                if (HoraFormatada.TotalMinutes > 60)
                    return HoraFormatada.TotalMinutes.ToString() + " minutos";
                else
                    return HoraFormatada.TotalHours.ToString() + " horas";
            }
        }

        public float Valor { get; set; }

        public ValorHora()
        {
            this.HoraFormatada = new TimeSpan();
            this.Valor = 0.00f;
        }

        public ValorHora(TimeSpan horaFormatada, float valor)
        {
            this.Valor = Valor;
            this.HoraFormatada = horaFormatada;
        }
    }
}
