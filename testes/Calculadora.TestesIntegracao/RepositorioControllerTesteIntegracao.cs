using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Calculadora.WebApi;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Calculadora.TestesIntegracao {
    public class RepositorioControllerTesteIntegracao : IClassFixture<CustomWebApplicationFactory<Startup>> {
        private readonly HttpClient _client;

        public RepositorioControllerTesteIntegracao (CustomWebApplicationFactory<Startup> factory) {
            _client = factory.CreateClient ();
        }

        [Theory]
        [InlineData ("/api/repositorio/showmethecode", "OK")]
        public async Task ShowMeTheCode (string url, string expectedStatusCode) {
            var httpResponse = await _client.GetAsync (url);
            httpResponse.EnsureSuccessStatusCode ();
            Assert.True (httpResponse.IsSuccessStatusCode);
            Assert.Equal (expectedStatusCode, httpResponse.EnsureSuccessStatusCode ().StatusCode.ToString ());
        }
    }
}