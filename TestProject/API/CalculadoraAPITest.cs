using Xunit;
using System.Net.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using CalculadoraJurosCore;
using System.Threading.Tasks;
using System.Net;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text;

namespace TestProject.API
{
    public class CalculadoraAPITest
    {
        private readonly HttpClient _client;

        public CalculadoraAPITest()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<Startup>());
            _client = server.CreateClient();
        }

        [Theory]
        [InlineData(100, 5)]
        public async Task PostCalcularJurosTesteAsync(decimal valorInicial, int meses)
        {
            var json = JsonConvert.SerializeObject(new { valorInicial, meses });
            var response = await _client.PostAsync("/api/Calculadora/CalculaJuros", new StringContent(json, Encoding.UTF8, "application/json"));

            // Assert 
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
