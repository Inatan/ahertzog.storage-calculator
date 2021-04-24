using Store.Calculator.Domain.Utils;
using System;
using Xunit;

namespace Store.Calculator.Tests
{
    public class EventUtilsValidaDecimal
    {
        [Theory]
        [InlineData("3,2", "2")]
        [InlineData("3,2", "5")]
        [InlineData("3", ",")]
        public void DadoTextoValorDecimalRetornaFals(string textoEntrada, string digitoEntrada)
        {
            // arrange
            // act
            var ehDecimal = EventsUtils.ValidaDecimal(textoEntrada, digitoEntrada);
            // assert
            Assert.False(ehDecimal);
        
        
        }

        [Theory]
        [InlineData("3,2","a")]
        [InlineData("3,2",",")]
        [InlineData("3,2","$")]
        [InlineData("",",")]
        public void DadoTextoComLetraslRetornaTrue(string textoEntrada, string digitoEntrada)
        {
            // arrange
            // act
            var ehDecimal = EventsUtils.ValidaDecimal(textoEntrada, digitoEntrada);
            // assert
            Assert.True(ehDecimal);
        }
    }
}
