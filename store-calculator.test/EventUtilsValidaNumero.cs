using Store.Calculator.Model.Utils;
using Xunit;

namespace Store.Calculator.Tests
{
    public class EventUtilsValidaNumero
    {
        [Theory]
        [InlineData("", "2")]
        [InlineData("3", "2")]
        [InlineData("32", "2")]
        public void DadoTextoValorDecimalRetornaFals(string textoEntrada, string digitoEntrada)
        {
            // arrange
            // act
            var ehDecimal = EventsUtils.ValidaNumero(textoEntrada, digitoEntrada);
            // assert
            Assert.False(ehDecimal);


        }

        [Theory]
        [InlineData("3", "a")]
        [InlineData("3", ",")]
        [InlineData("3", "$")]
        public void DadoTextoComLetraslRetornaTrue(string textoEntrada, string digitoEntrada)
        {
            // arrange
            // act
            var ehDecimal = EventsUtils.ValidaNumero(textoEntrada, digitoEntrada);
            // assert
            Assert.True(ehDecimal);
        }
    }
}
