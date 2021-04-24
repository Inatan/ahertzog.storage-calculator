using Xunit;
using Store.Calculator.Domain;


namespace Store.Calculator.Tests
{
    public  class ModelMaterialConsumoTotal
    {
        
        [Fact]
        void DadoUmMateriaComQuantidadeRetornaroValorTotalExperado()
        {
            //arrange
            Material materialConsumo = new Material("Navalha", "UN", 1, 1, 10.5M, 10.5M);
            decimal quantidade = 2.00M;
            ConsumoMaterial consumo = new ConsumoMaterial(materialConsumo, quantidade);

            decimal valorEsperado = 42.00M;
            //act
            var total = consumo.Total;

            //assert
            Assert.Equal(total, valorEsperado);
        }
    }
}
