using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace Store.Calculator.Domain.Utils
{
    public class Importador
    {
        public List<ValorServico> LeValorServico(string fileName)
        {
            List<ValorServico> valoresServicos = new List<ValorServico>();
            CultureInfo cultureInfo = new CultureInfo("pt-br");
            using (StreamReader sr = new StreamReader(fileName, Encoding.UTF8,true))
            {
                string currentLine;
                while ((currentLine = sr.ReadLine()) != null)
                {
                    string[] linhaSeparada = currentLine.Split(';');
                    string nome = linhaSeparada[0];
                    decimal valor = Decimal.Parse(linhaSeparada[1].Replace("R$", "").Trim(), NumberStyles.Currency, cultureInfo);
                    valoresServicos.Add(new ValorServico(nome, valor));
                }
            }
            return valoresServicos;
        }

        public List<Material> LeMateriais(string fileName)
        {
            List<Material> materials = new List<Material>();
            CultureInfo cultureInfo = new CultureInfo("pt-br");
            using (StreamReader sr = new StreamReader(fileName, Encoding.GetEncoding("utf-8")))
            {
                string currentLine;
                while ((currentLine = sr.ReadLine()) != null)
                {
                    string[] linhaSeparada = currentLine.Split(';');
                    string nome = linhaSeparada[0];
                    string unidade = linhaSeparada[1];
                    int quantidade = Convert.ToInt32(linhaSeparada[2]);
                    int quantoFaz = Convert.ToInt32(linhaSeparada[3]);
                    decimal valorFrete = Decimal.Parse(linhaSeparada[4].Replace("R$", "").Trim(), NumberStyles.Currency, cultureInfo);
                    decimal valorPago = Decimal.Parse(linhaSeparada[5].Replace("R$", "").Trim(), NumberStyles.Currency, cultureInfo);
                    materials.Add(new Material(nome, unidade, quantidade, quantoFaz, valorFrete, valorPago));
                }
            }
            return materials;
        }
    }
}
