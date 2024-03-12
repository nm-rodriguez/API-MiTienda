using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using MiTienda.Application.Contracts;
using MiTienda.Application.DTOs;
using MiTienda.Domain.Contracts;
using MiTienda.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiTienda.Application.Services
{
    public class VentaManageService : IManageVentaService
    {
        private IRepository<Venta> _ventaRepo;
        private IRepository<Sucursal> _sucursalRepo;
        private IRepository<Vendedor> _vendedorRepo;
        private IRepository<Cliente> _clienteRepo;
        private IRepository<TipoComprobante> _tipoComprobanteRepo;
        private IRepository<PuntoDeVenta> _puntoDeVentaRepo;
        private IRepository<LineaDeVenta> _lineaVentaRepo;//ver si es correcto que se cree aquí
        private IQueryService<Stock> _stockQuery;
        private IManageLineasVentaService _manageServiceLinea;
        //private IRepository<Pago> _pagoRepo;
        //private IRepository<Stock> _stockRepo;


        public VentaManageService(IRepository<Venta> ventaRepo, IRepository<Sucursal> sucursalRepo, IRepository<Vendedor> vendedorRepo, IRepository<Pago> pagoRepo, IRepository<Cliente> clienteRepo, IRepository<TipoComprobante> tipoComprobanteRepo, IRepository<PuntoDeVenta> puntoDeVentaRepo, IRepository<LineaDeVenta> lineaVentaRepo, IQueryService<Stock> stockQuery, IManageLineasVentaService manageServiceLinea)
        {
            _ventaRepo = ventaRepo;
            _sucursalRepo = sucursalRepo;
            _vendedorRepo = vendedorRepo;
            _clienteRepo = clienteRepo;
            _tipoComprobanteRepo = tipoComprobanteRepo;
            _puntoDeVentaRepo = puntoDeVentaRepo;
            _lineaVentaRepo = lineaVentaRepo;
            _stockQuery = stockQuery;
            _manageServiceLinea = manageServiceLinea;
            //_pagoRepo = pagoRepo;
        }

        public int CrearVenta(VentaPostDTO ventaPostDTO)
        {
            if (ventaPostDTO == null)
                throw new Exception("Venta nula.");

            Vendedor vendedor = _vendedorRepo.GetByID(ventaPostDTO.VendedorID).SingleOrDefault();
            Cliente cliente = _clienteRepo.GetBy(x => x.Dni == 0 && x.Apellido == "DefaultUser").SingleOrDefault();
            PuntoDeVenta ptoVenta = _puntoDeVentaRepo.GetByID(ventaPostDTO.PuntoDeVentaID).SingleOrDefault();
            Sucursal sucursal = _sucursalRepo.GetByID(ventaPostDTO.SucursalID).SingleOrDefault();
            //TipoComprobante tComprobante = _tipoComprobanteRepo.GetByID(ventaPostDTO.TipoComprobanteID).SingleOrDefault();
            //Pago pago = _pagoRepo.GetByID(ventaPostDTO.PagoID).SingleOrDefault();

            Venta venta = new Venta()
            {
                FechaVenta = DateTime.UtcNow,
                Vendedor = vendedor,
                Pago = null,
                Cliente = cliente,
                TipoComprobante = null,
                PuntoDeVenta = ptoVenta,
                Sucursal = sucursal,
                Importe = 0
            };

            _ventaRepo.AddObject(venta);
            return (venta.Id);
        }

        public string UpdateImporteVenta(int idVenta)
        {
            Venta venta = GetVentaById(idVenta);
            List<LineaDeVenta> detalleVenta = _manageServiceLinea.GetLineasByVentaID(idVenta);
            venta.GetTotal(detalleVenta);
            _ventaRepo.Update(venta);
            return $"La venta {venta.Id} se actualizó correctamente. El importe total es: {venta.Importe} ";
        }

        public Venta GetVentaById(int id)
        {
            Venta venta = _ventaRepo.GetByID(id).AsQueryable()
                .Include(x => x.Sucursal)
                .Include(x => x.Vendedor)
                .Include(x => x.Pago)
                .Include(x => x.Pago.TipoPago)
                .Include(x => x.Cliente)
                .Include(x => x.TipoComprobante)
                .Include(x => x.PuntoDeVenta)
                .Include(x => x.PuntoDeVenta.Sucursal)
                .Include(x => x.PuntoDeVenta.Sucursal.Tienda)
                .SingleOrDefault();

            venta.LineasDeVenta = _lineaVentaRepo.GetBy(x => x.VentaID == venta.Id)
                .AsQueryable()
                .Include(x => x.Stock)
                .Include(x => x.Stock.Articulo)
                .Include(x => x.Stock.Articulo.Marca)
                .Include(x => x.Stock.Articulo.Categoria)
                .Include(x => x.Stock.Color)
                .Include(x => x.Stock.Talle)
                .Include(x => x.Stock.Talle.TipoTalle)
                .ToList();
            return venta;
        }

        public List<Venta> GetVentas()
        {
            //List<VentaDTO> ventas = new List<VentaDTO>();

            //foreach (var venta in _ventaRepo.GetAll().AsQueryable()
            //    .Include(x => x.Sucursal)
            //    .Include(x => x.Vendedor)
            //    .Include(x => x.Pago)
            //    .Include(x => x.Pago.TipoPago)
            //    .Include(x => x.Cliente)
            //    .Include(x => x.TipoComprobante)
            //    .Include(x => x.PuntoDeVenta)
            //    .Include(x => x.PuntoDeVenta.Sucursal)
            //    )
            //{   ventas.Add(new VentaDTO(venta)); }

            return _ventaRepo.GetAll().AsQueryable()
                .Include(x => x.Sucursal)
                .Include(x => x.Vendedor)
                .Include(x => x.Pago)
                .Include(x => x.Pago.TipoPago)
                .Include(x => x.Cliente)
                .Include(x => x.TipoComprobante)
                .Include(x => x.PuntoDeVenta)
                .Include(x => x.PuntoDeVenta.Sucursal)
                .Include(x => x.PuntoDeVenta.Sucursal.Tienda)
                .ToList();
        }
        public List<VentaDTO> GetVentasBySucursal(int idSucursal)
        {
            //List<ReturnInventarioDTO> inventarios = new List<ReturnInventarioDTO>();

            //foreach (Inventario inventario in _inventarioRepo.GetBy(i => i.Id == idInventario).AsQueryable().Include(x => x.Stock).Include(x => x.Sucursal).Include(x => x.Stock.Color).Include(x => x.Stock.Talle).Include(x => x.Stock.Articulo).Include(x => x.Stock.Articulo.Marca).Include(x => x.Stock.Articulo.Categoria).Include(x => x.Stock.Talle.TipoTalle))
            //{
            //    ReturnInventarioDTO InventarioDTO = new ReturnInventarioDTO(inventario);
            //    inventarios.Add(InventarioDTO);
            //}
            //return inventarios.Count > 0 ? inventarios : null;
            throw new NotImplementedException();
        }

        public List<VentaDTO> GetVentasByEmpleado(int idEmpleado)
        {
            throw new NotImplementedException();
        }

    }
}
