using Microsoft.EntityFrameworkCore;
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
        private IRepository<Pago> _pagoRepo;
        private IRepository<Cliente> _clienteRepo;
        private IRepository<TipoComprobante> _tipoComprobanteRepo;
        private IRepository<PuntoDeVenta> _puntoDeVentaRepo;

        public VentaManageService(IRepository<Venta> ventaRepo, IRepository<Sucursal> sucursalRepo, IRepository<Vendedor> vendedorRepo, IRepository<Pago> pagoRepo, IRepository<Cliente> clienteRepo, IRepository<TipoComprobante> tipoComprobanteRepo, IRepository<PuntoDeVenta> puntoDeVentaRepo)
        {
            _ventaRepo = ventaRepo;
            _sucursalRepo = sucursalRepo;
            _vendedorRepo = vendedorRepo;
            _pagoRepo = pagoRepo;
            _clienteRepo = clienteRepo;
            _tipoComprobanteRepo = tipoComprobanteRepo;
            _puntoDeVentaRepo = puntoDeVentaRepo;
        }

        public string CrearVenta(VentaPostDTO ventaPostDTO)
        {
            if (ventaPostDTO == null)
                throw new Exception("Venta nula.");

            Vendedor vendedor = _vendedorRepo.GetByID(ventaPostDTO.VendedorID).SingleOrDefault();
            Pago pago = _pagoRepo.GetByID(ventaPostDTO.PagoID).SingleOrDefault();
            Cliente cliente= _clienteRepo.GetByID(ventaPostDTO.ClienteID).SingleOrDefault();
            TipoComprobante tComprobante = _tipoComprobanteRepo.GetByID(ventaPostDTO.TipoComprobanteID).SingleOrDefault();
            PuntoDeVenta ptoVenta = _puntoDeVentaRepo.GetByID(ventaPostDTO.PuntoDeVentaID).SingleOrDefault();
            Sucursal sucursal = _sucursalRepo.GetByID(ventaPostDTO.SucursalID).SingleOrDefault();


            Venta venta = ventaPostDTO.CastearAVenta(
                DateTime.Parse(ventaPostDTO.FechaVenta),
                vendedor,
                pago,
                cliente,
                tComprobante,
                ptoVenta,
                sucursal
                );

            _ventaRepo.AddObject(venta);

            return $"Venta creada correctamente ID: {venta.Id}";
        }


        public List<VentaDTO> GetVentas()
        {
            List<VentaDTO> ventas = new List<VentaDTO>();

            foreach (var item in _ventaRepo.GetAll()
                .AsQueryable()
                .Include(x => x.Sucursal)
                .Include(x => x.Vendedor)
                .Include(x => x.Pago)
                .Include(x => x.Pago.TipoPago)
                .Include(x => x.Cliente)
                .Include(x => x.TipoComprobante)
                .Include(x => x.PuntoDeVenta)
                )
            {
                ventas.Add(new VentaDTO(item));
            }

            return ventas;
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
