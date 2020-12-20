namespace Store.Calculator.Model
{
    public class ConsumoMaterial
    {
        public decimal Total 
        {
            get 
            {
                return MaterialConsumido.TotalUnitarioFinal * Quantidade;
            }
        }
        public Material MaterialConsumido { get; }
        public decimal Quantidade { get; set; }


        public ConsumoMaterial(Material consumo, decimal quantidade)
        {
            MaterialConsumido = consumo;
            Quantidade = quantidade;
        }

    }
}
