using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using MiTienda.Application.DTOs;

namespace API_MiTienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DecidirController : ControllerBase
    {
        private readonly HttpClient _clientWithTokenApi;
        private readonly HttpClient _clientWithPaymentsApi;

        public DecidirController()
        {
            _clientWithTokenApi = new HttpClient();
            _clientWithTokenApi.BaseAddress = new Uri("https://developers.decidir.com/api/v2/");
            _clientWithTokenApi.DefaultRequestHeaders.Add("apikey", "b192e4cb99564b84bf5db5550112adea");

            _clientWithPaymentsApi = new HttpClient();
            _clientWithPaymentsApi.BaseAddress = new Uri("https://developers.decidir.com/api/v2/");
            _clientWithPaymentsApi.DefaultRequestHeaders.Add("apikey", "566f2c897b5e4bfaa0ec2452f5d67f13");
        }

        [HttpPost("token")]
        public async Task<ActionResult<TarjetaDTO>> ObtenerToken([FromBody] TarjetaDTO tarjeta)
        {
            HttpResponseMessage response = await _clientWithTokenApi.PostAsJsonAsync("tokens", tarjeta);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();

                TarjetaWithTokenDTO responseDto = JsonSerializer.Deserialize<TarjetaWithTokenDTO>(content);

                string id = responseDto.id;

                return Ok(new { id });
            }
            else
            {
                return StatusCode((int)response.StatusCode, "Error al obtener el token");
            }
        }

        [HttpPost("PayWithCard")]
        public async Task<ActionResult> EfectuarPago([FromBody] PagoTarjetaDTO Pago)
        {
            HttpResponseMessage response = await _clientWithPaymentsApi.PostAsJsonAsync("payments", Pago);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                PagoTarjetaRespuestaDTO pagoTarjetaRespuesta = JsonSerializer.Deserialize<PagoTarjetaRespuestaDTO>(content);


                return Ok( pagoTarjetaRespuesta );
            }
            else
            {
                return StatusCode((int)response.StatusCode, "Error al realizar el pago");
            }
        }
    }
}
