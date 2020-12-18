using System;

namespace Store.Calculator.Model
{
    public class Material
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Unidade { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorPago { get; set; }
        public decimal ValorFrete { get; set; }
        public int QuantoFaz { get; set; }
        public string Medida { get { return Quantidade.ToString() + " " + Unidade; } }
        public decimal TotalFinal { get { return Math.Round((ValorPago + ValorFrete)/Quantidade,2); } }
        public decimal TotalUnitarioFinal { get { return Math.Round((TotalFinal / QuantoFaz), 2); } }

        public Material()
        {
            Id = 0;
            Nome = String.Empty;
            Quantidade = 0;
            Unidade = " UN.";
            QuantoFaz = 0;
            ValorPago = 0.00M;
            ValorFrete = 0.00M;
        }

        public Material(string nome, string unidade,int quantidade, 
                                int quantoFaz, decimal valorFrete, decimal valorPago)
        {
            Id = 0;
            Nome = nome;
            Unidade = unidade;
            Quantidade = quantidade;
            QuantoFaz = quantoFaz;
            ValorPago = valorPago;
            ValorFrete = valorFrete;
        }

        public static string CalculaValorUnitario(string quantidade, string quantosFaz, string valorPago, string valorFrete)
        {
            string valorUnitario = string.Empty;
            if (!string.IsNullOrEmpty(quantidade) && !string.IsNullOrEmpty(quantosFaz) && !string.IsNullOrEmpty(valorPago) && !string.IsNullOrEmpty(valorFrete))
            {
                int qtd = Convert.ToInt32(quantidade), qtFaz = Convert.ToInt32(quantosFaz);
                decimal pago = Convert.ToDecimal(valorPago), frete = Convert.ToDecimal(valorFrete);
                valorUnitario = Math.Round((((pago / qtd) + frete) / qtFaz), 2).ToString().Replace(".", ",");
            }
            return valorUnitario;
        }
    }
}
