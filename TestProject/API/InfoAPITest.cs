using CalculadoraJurosCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace TestProject.API
{
    public class InfoAPITest
    {
        private readonly HttpClient _client;

        public InfoAPITest()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<Startup>());
            _client = server.CreateClient();
        }

        [Theory]
        [InlineData("GET")]
        public async Task GetShowMeTheCode(string method)
        {
            var request = new HttpRequestMessage(new HttpMethod(method), "api/Info/ShowMeTheCode");
            
            var response = await _client.SendAsync(request);

            // Assert 
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
