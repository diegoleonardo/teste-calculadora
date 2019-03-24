using Calculadora.Core;
using Microsoft.AspNetCore.Mvc;

namespace Calculadora.WebApi.Controllers {
    [Route ("api/calculadora")]
    [ApiController]
    public class CalculadoraController : ControllerBase {
        private readonly ICalculadoraJuros _calculadoraJuros;
        public CalculadoraController (ICalculadoraJuros calculadoraJuros) {
            _calculadoraJuros = calculadoraJuros;
        }

        [HttpGet]
        [Route ("calculajuros")]
        public ActionResult<decimal> CalculaJurosComposto (int valorinicial, int meses) {
            var valorFuturo = _calculadoraJuros.Calcular (valorinicial, meses);

            return valorFuturo;
        }
    }
}