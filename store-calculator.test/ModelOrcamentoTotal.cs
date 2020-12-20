using Store.Calculator.Model;
using System.Collections.Generic;
using Xunit;

namespace Store.Calculator.Tests
{
    public class ModelOrcamentoTotal
    {
        [Fact]
        void DadoUmMateriaComQuantidadeRetornaroValorTotalExperado()
        {
            //arrange
            var materiaisConsumo = new List<ConsumoMaterial>
            {
                new ConsumoMaterial(new Material("Navalha","UN",1,1,10.5M,10.5M),10),
                new ConsumoMaterial(new Material("Linha","UN",1,1,1.5M,0.5M),2),
                new ConsumoMaterial(new Material("Papel","g",1,1,10M,4M),1),
            };

            Orcamento orcamento = new Orcamento(new System.TimeSpan(0, 2, 0, 0, 0), materiaisConsumo);

            decimal valorEsperado = 260.00M;
            //act
            var total = orcamento.Total;

            //assert
            Assert.Equal(total, valorEsperado);
        }
    }
}
