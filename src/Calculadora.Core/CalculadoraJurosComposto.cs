namespace Calculadora.Core {
    using System;
    public class CalculadoraJurosComposto : ICalculadoraJuros {
        /// <summary>Calcula Juros Composto</summary>
        public decimal Calcular (double valorInicial, int meses, double porcentagemJuros, int casaDecimal = 2) {
            if (this.MenorIgualAZero (meses) || this.MenorIgualAZero (valorInicial)) {
                return 0;
            }
            var montante = Math.Pow ((1 + porcentagemJuros), meses);
            montante = montante * valorInicial;
            var valorFuturo = decimal.Round ((decimal) montante, casaDecimal, MidpointRounding.AwayFromZero);

            return valorFuturo;
        }

        private bool MenorIgualAZero (double valor) {
            return valor <= 0;
        }
    }
}