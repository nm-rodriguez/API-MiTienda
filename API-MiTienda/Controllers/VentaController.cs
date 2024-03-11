using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiTienda.Application.Contracts;
using MiTienda.Application.DTOs;
using MiTienda.Domain.Contracts;
using MiTienda.Domain.Entities;
using System.Collections;
using System.Drawing;
using System.ServiceModel.Channels;

namespace API_MiTienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private IManageVentaService _manageService;
        private IManageLineasVentaService _manageServiceLinea;
        private IVenta _ventaEnMemoria;
        private IQueryService<Stock> _stockQuery;
        private IQueryService<LineaDeVenta> _lineaQuery;

        public VentaController(IManageVentaService manageService, IManageLineasVentaService manageServiceLinea, IVenta ventaEnMemoria, IQueryService<Stock> stockQuery, IQueryService<LineaDeVenta> lineaQuery)
        {
            _manageService = manageService;
            _manageServiceLinea = manageServiceLinea;
            _ventaEnMemoria = ventaEnMemoria;
            _stockQuery = stockQuery;
            _lineaQuery = lineaQuery;
        }



        #region Parte 1 - VENTA
        [HttpPost("postLineasLocal")]
        public ActionResult<IEnumerable<List<LineaDeVenta>>> PostLineasEnLocal(List<LineaVentaDTO> lineasVentaDTO)
        {
            try
            {
                LineaDeVenta lineaV;
                Stock stock;
                List<LineaDeVenta> lineaDeVenta = new List<LineaDeVenta>();

                foreach (var linea in lineasVentaDTO)
                {
                    stock = _stockQuery.GetBy(s => s.Id == linea.StockID)
                    .Include(c => c.Color)
                    .Include(a => a.Articulo)
                    .Include(t => t.Talle)
                    .Include(tt => tt.Talle.TipoTalle)
                    .Include(x => x.Articulo.Marca)
                    .Include(x => x.Articulo.Categoria)
                    .SingleOrDefault();

                    lineaV = new LineaDeVenta() { Cantidad = linea.Cantidad, Stock = stock, VentaID = 0 };
                    // no puedo agregar la linea porque no tiene venta creada para darle el id
                    //_manageServiceLinea.CrearLineaVenta(lineaV);

                    lineaDeVenta.Add(lineaV);
                }
                _ventaEnMemoria.AgregarArticulos(lineaDeVenta);

                return Ok("Lineas de venta agregadas correctamente en memoria local.");
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"Algo salió mal. Detalles: {ex.Message}");
            }
        }

        #endregion

        #region Parte 2 - VENTA
        [HttpPost]
        public ActionResult<VentaPostDTO> PostVenta(VentaPostDTO venta)
        {
            try
            {
                _ventaEnMemoria.SetID(_manageService.CrearVenta(venta));
                return Ok($"Venta creada exitosamente,{_ventaEnMemoria.GetID()}");
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"Algo salió mal. Detalles: {ex.Message}");
            }
        }

        [HttpPost("postLineasEnDB")]
        public ActionResult<IEnumerable<List<LineaDeVenta>>> PostLineasEnDB()
        {
            try
            {
                foreach (var linea in _ventaEnMemoria.GetLineas())
                {
                    linea.VentaID = _ventaEnMemoria.GetID();
                    _manageServiceLinea.CrearLineaVenta(linea);
                }
                //var message = _manageServiceLinea.CrearLineasVenta(_ventaEnMemoria.GetLineas());
                //return Ok(message);
                return Ok();

            }
            catch (Exception ex)
            {
                return StatusCode(400, $"Algo salió mal. Detalles: {ex.Message}");
            }
        }
        #endregion













        [HttpGet("lineas")]
        public ActionResult<IEnumerable<LineaVentaDTO>> GetAllLineasVentas()
        {
            try
            {
                var lineas = _lineaQuery.GetAll();
                return Ok(lineas);
            }
            catch (Exception)
            {
                return StatusCode(400, "Algo salió mal.");
            }
        }
        [HttpGet]
        public ActionResult<IEnumerable<VentaDTO>> GetAllVentas()
        {
            try
            {
                var ventas = _manageService.GetVentas();
                return Ok(ventas);
            }
            catch (Exception)
            {
                return StatusCode(400, "Algo salió mal.");
            }
        }



        [HttpGet("ventaID")]
        public ActionResult<ClienteDTO> GetVentaById(int id)
        {
            //try
            //{
            //    var cliente = _manageService.GetClienteByIdOrDni(idordni);

            //    if (cliente == null)
            //        return NotFound($"No existe el cliente buscado. Por favor reintente su busqueda con un valor diferente.");

            //    return Ok(cliente);
            //}
            //catch (Exception)
            //{
            return StatusCode(400, "Algo salió mal. Verifica el id.");
            //}

        }

      

        

        [HttpPut]
        public ActionResult<ClienteDTO> UpdateVenta([FromBody] VentaDTO venta)
        {
            //try
            //{
            //    var message = _manageService.UpdateCliente(cliente);
            //    return Ok(message);
            //}
            //catch (Exception ex)
            //{
            //return StatusCode(400, $"Algo salió mal. Detalles: {ex.Message}");
            //}
            return StatusCode(400);
        }

        [HttpDelete("{ventaIDint}")]
        public ActionResult<int> DeleteVenta(int idVenta)
        {
            //try
            //{
            //    var message = _manageService.DeleteCliente(idCliente);
            //    return Ok(message);
            //}
            //catch (Exception ex)
            //{
            //    return StatusCode(400, $"Algo salió mal. Detalles: {ex.Message}");
            //}
            return StatusCode(400);

        }
    }
}
