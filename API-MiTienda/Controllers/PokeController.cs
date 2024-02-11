using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiTienda.Domain.Entities;

namespace API_MiTienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokeController : ControllerBase
    {

        static HttpClient _client;
        public PokeController()
        {   
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://pokeapi.co/api/v2/");

        }
        
        [HttpGet]
        public async Task<ActionResult> GetPokemons()
        {
            HttpResponseMessage response = await _client.GetAsync("pokemon");
            if (response.IsSuccessStatusCode)
            {
                string responseData = await response.Content.ReadAsStringAsync();
                return Ok(responseData);
            }
            else
            {
                return StatusCode((int)response.StatusCode, "Error al llamar a la API externa");
            }
        }
    }
}
