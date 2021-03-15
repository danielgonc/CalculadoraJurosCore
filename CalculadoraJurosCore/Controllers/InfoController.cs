using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculadoraJurosCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        [HttpGet, Route("ShowMeTheCode")]
        public IActionResult ShowMeTheCode()
        {
            return Ok(new { url = "https://github.com/danielgonc", obterTaxa = "https://github.com/danielgonc/APIObterJuros", calculoJuros = "" });
        }
    }
}
