using CalculadoraJurosCore.ObterJuros;
using CalculadoraJurosCore.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CalculadoraJurosCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculadoraController : ControllerBase
    {

        [HttpPost, Route("CalculaJuros")]
        public async Task<IActionResult> CalculaJuros(CalculaJurosViewModel viewModel)
        {
            try
            {
                var validator = new CalculaJurosViewModelValidator();
                var result = validator.Validate(viewModel);

                if (!result.IsValid)
                    return BadRequest(new { errors = result.Errors.Select(s => s.ErrorMessage).ToList() });

                HttpClient client = new HttpClient();
                var response = await client.GetAsync("https://api-obter-juros.azurewebsites.net/api/Juros/taxaJuros");
                var juros = JsonConvert.DeserializeObject<ResponseObterJuros>(await response.Content.ReadAsStringAsync());

                var jc = Math.Pow(Convert.ToDouble(1 + juros.taxa), viewModel.meses);
                var final = jc * Convert.ToDouble(viewModel.valorInicial);

                return Ok(new { valorFinal = final.ToString("F") });
            }
            catch (Exception e)
            {
                return BadRequest(new { errors = new string[] { e.Message } });
            }
        }
    }
}
