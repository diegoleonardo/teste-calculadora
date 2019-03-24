namespace Calculadora.Core {
    public interface ICalculadoraJuros {
        decimal Calcular (double valorInicial, int meses, double porcentagemJuros = 0.01, int casaDecimal = 2);
    }
}