using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Calculadora.WebApi;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Calculadora.TestesIntegracao {
    public class CalculadoraControllerTesteIntegracao : IClassFixture<CustomWebApplicationFactory<Startup>> {
        private readonly HttpClient _client;
        public CalculadoraControllerTesteIntegracao (CustomWebApplicationFactory<Startup> factory) {
            _client = factory.CreateClient ();
        }

        [Theory]
        [InlineData (-1, -2, "0.0")]
        [InlineData (-1, 0, "0.0")]
        [InlineData (-1, 5, "0.0")]
        [InlineData (10, -5, "0.0")]
        [InlineData (100, 5, "105.10")]
        [InlineData (200, 5, "210.20")]
        public async Task CalcularJurosCompostos (int valorInicial, int meses, string expected) {
            var httpResponse = await _client.GetAsync ($"/api/calculadora/calculajuros?valorinicial={valorInicial}&meses={meses}");
            httpResponse.EnsureSuccessStatusCode ();
            Assert.Equal (true, httpResponse.IsSuccessStatusCode);
            Assert.Equal ("application/json; charset=utf-8", httpResponse.Content.Headers.ContentType.ToString ());
            Assert.Equal (expected, await httpResponse.Content.ReadAsStringAsync ());
        }
    }
}