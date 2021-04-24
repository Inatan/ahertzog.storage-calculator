using System;

namespace Store.Calculator.Domain
{
    public class ValorTempo
    {
        public TimeSpan HoraFormatada { get; set; }
        public string Tempo {
            get
            {
                if (HoraFormatada.TotalMinutes > 60)
                    return HoraFormatada.TotalMinutes.ToString() + " minutos";
                else
                    return HoraFormatada.TotalHours.ToString() + " horas";
            }
        }

        public float Valor { get; set; }

        public ValorTempo()
        {
            this.HoraFormatada = new TimeSpan();
            this.Valor = 0.00f;
        }

        public ValorTempo(TimeSpan horaFormatada, float valor)
        {
            this.Valor = Valor;
            this.HoraFormatada = horaFormatada;
        }
    }
}
