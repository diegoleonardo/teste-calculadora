using Calculadora.Core;
using NUnit.Framework;

namespace Tests {
    public class CalculadoraJurosCompostoTeste {
        [TestCase (100, 5, 0.01d, ExpectedResult = 105.10)]
        [TestCase (100, 5, 0.01d, 3, ExpectedResult = 105.101)]
        public decimal CalculoDeJurosComposto (int valorInicial, int meses, double porcentagemJuros, int casasDecimais = 2) {
            var calculadora = new CalculadoraJurosComposto ();
            var resultado = calculadora.Calcular (valorInicial, meses, porcentagemJuros, casasDecimais);

            return resultado;
        }
    }
}