using Store.Calculator.Model;
using Xunit;

namespace Store.Calculator.Tests
{
    public class ModelEstoqueMateriaPrimaCalculaValorUnitario
    {
        [Theory]
        [InlineData("15", "1", "1","10","5")]
        [InlineData("1,5", "1", "10","10","5")]
        [InlineData("6", "10", "1","10","5")]
        [InlineData("0,6", "10", "10","10","5")]
        void DadoValoresDeCalculoRetornaResultadoEsperado(string valorEsperado, string quantidade, string quantosFaz, string valorPago, string valorFrete)
        {
            //arrange
            //act
            string retorno = EstoqueMateriaPrima.CalculaValorUnitario(quantidade, quantosFaz, valorPago, valorFrete);

            //assert
            Assert.Equal(valorEsperado, retorno);
        }
    }
}
