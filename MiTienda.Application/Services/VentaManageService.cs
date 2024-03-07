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

        public VentaManageService(IRepository<Venta> ventaRepo, IRepository<LineaDeVenta> lineaVentaRepo)
        {
            _ventaRepo = ventaRepo;
        }

        public string CrearVenta(VentaDTO ventaDTO)
        {
            if (ventaDTO == null)
                throw new Exception("Venta nula.");
            Venta venta = new Venta() { };//ventaDTO.CastearAVenta();
            venta.Sucursal = new Sucursal(){};
            venta.FechaVenta = new DateTime(){};
            venta.Vendedor = new Vendedor(){};
            venta.Pago = new Pago(){};
            venta.Cliente = new Cliente(){};
            venta.TipoComprobante = new TipoComprobante(){};
            venta.PuntoDeVenta = new PuntoDeVenta() { };


            return $"Venta creada correctamente ID: {venta.Id} , FECHA: {venta.FechaVenta}, SUCURSAL: {venta.Sucursal.Nombre},TOTAL: {venta.Pago.Monto}";
        }


        public List<VentaDTO> GetVentas(int idSucursal)
        {
            List<VentaDTO> ventas = new List<VentaDTO>();

            //foreach (Inventario inventario in _inventarioRepo.GetBy(i => i.Sucursal.Id == idSucursal)
            //    .AsQueryable()
            //    .Include(x => x.Stock)
            //    .Include(x => x.Sucursal)
            //    .Include(x => x.Stock.Color)
            //    .Include(x => x.Stock.Talle)
            //    .Include(x => x.Stock.Articulo)
            //    .Include(x => x.Stock.Articulo.Marca)
            //    .Include(x => x.Stock.Articulo.Categoria)
            //    .Include(x => x.Stock.Talle.TipoTalle))
            //{
            //    inventarios.Add(new ReturnInventarioDTO(inventario));
            //}

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
