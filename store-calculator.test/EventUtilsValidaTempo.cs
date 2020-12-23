using Store.Calculator.Model.Utils;
using Xunit;

namespace Store.Calculator.Tests
{
    public class EventUtilsValidaTempo
    {
        [Theory]
        [InlineData("", "2")]
        [InlineData("2", "3")]
        [InlineData("", "8")]
        [InlineData("23", ":")]
        [InlineData("23:", "4")]
        [InlineData("23:4", "5")]
        [InlineData("2", "8")]
        [InlineData("8", "1")]
        public void DadoTextoValorDecimalRetornaFals(string textoEntrada, string digitoEntrada)
        {
            // arrange
            // act
            var ehDecimal = EventsUtils.ValidaTempo(textoEntrada, digitoEntrada);
            // assert
            Assert.False(ehDecimal);
        }

        [Theory]
        [InlineData("3", "a")]
        [InlineData("3", ",")]
        [InlineData("3", "$")]
        [InlineData("23:", "7")]
        [InlineData("12:3", ":")]
        public void DadoTextoComLetraslRetornaTrue(string textoEntrada, string digitoEntrada)
        {
            // arrange
            // act
            var ehDecimal = EventsUtils.ValidaTempo(textoEntrada, digitoEntrada);
            // assert
            Assert.True(ehDecimal);
        }
    }
}
