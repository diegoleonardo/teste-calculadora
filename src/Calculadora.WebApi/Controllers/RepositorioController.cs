using Microsoft.AspNetCore.Mvc;

namespace Calculadora.WebApi.Controllers {
    [Route ("api/repositorio")]
    [ApiController]
    public class RepositorioController : ControllerBase {
        private const string REPOSITORIO_CALCULADORA = "https://github.com/diegoleonardo/teste-calculadora";
        [HttpGet]
        [Route ("showmethecode")]
        public string Get () {
            return REPOSITORIO_CALCULADORA;
        }
    }
}