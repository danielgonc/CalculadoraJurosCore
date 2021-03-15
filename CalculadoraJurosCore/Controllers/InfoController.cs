using Microsoft.AspNetCore.Mvc;

namespace CalculadoraJurosCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        [HttpGet, Route("ShowMeTheCode")]
        public IActionResult ShowMeTheCode()
        {
            return Ok(new { url = "https://github.com/danielgonc", obterTaxa = "https://github.com/danielgonc/APIObterJuros", calculoJuros = "https://github.com/danielgonc/CalculadoraJurosCore" });
        }
    }
}
