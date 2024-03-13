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
    public class PagoManageService : IManagePagoService
    {
        private IRepository<Venta> _ventaRepo;
        private IRepository<TipoPago> _tipoPagoRepo;
        private IRepository<DetallePagoTarjeta> _detalleTarjetaRepo;

        public PagoManageService(IRepository<Venta> ventaRepo, IRepository<TipoPago> tipoPagoRepo, IRepository<DetallePagoTarjeta> detalleTarjetaRepo)
        {
            _ventaRepo = ventaRepo;
            _tipoPagoRepo = tipoPagoRepo;
            _detalleTarjetaRepo = detalleTarjetaRepo;
        }

        public Pago CrearPago(PagoPostDTO pagoDTO)
        {
            if (pagoDTO == null)
                throw new Exception("PagoDTO nulo.");

            Pago pago = new Pago();
            pago.TipoPago = _tipoPagoRepo.GetByID(pagoDTO.idTipoPago).SingleOrDefault();
            
            if (pago.TipoPago != _tipoPagoRepo.GetBy(x => x.Descripcion == "Efectivo"))
            {
                    pago.DetallePagoTarjeta =  _detalleTarjetaRepo.GetByID((int)pagoDTO.idTipoTarjeta).SingleOrDefault();
                    //pago.Venta = _tipoPagoRepo.GetByID(pagoDTO.idTipoPago);
                    //llama a decidir

                    DetallePagoTarjeta detallePago = new DetallePagoTarjeta();
                    detallePago.TipoTarjeta = _tipoPagoRepo.GetByID(pagoDTO.idTipoPago).SingleOrDefault().Descripcion;
                    detallePago.Ticket = pagoDTO.token;
                    _detalleTarjetaRepo.AddObject(detallePago);
                
            }
            pago.Moneda = "ARS";
            pago.FechaPago = DateTime.Now;
            pago.Monto = pagoDTO.Monto;


            return pago;
        }       

        public Pago GetPagoById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Pago> GetPagos()
        {
            throw new NotImplementedException();
        }




        //public int CrearVenta(VentaPostDTO ventaPostDTO)
        //{
        //    if (ventaPostDTO == null)
        //        throw new Exception("Venta nula.");

        //    Vendedor vendedor = _vendedorRepo.GetByID(ventaPostDTO.VendedorID).SingleOrDefault();
        //    Cliente cliente = _clienteRepo.GetBy(x => x.Dni == 0 && x.Apellido == "DefaultUser").SingleOrDefault();
        //    PuntoDeVenta ptoVenta = _puntoDeVentaRepo.GetByID(ventaPostDTO.PuntoDeVentaID).SingleOrDefault();
        //    Sucursal sucursal = _sucursalRepo.GetByID(ventaPostDTO.SucursalID).SingleOrDefault();
        //    //TipoComprobante tComprobante = _tipoComprobanteRepo.GetByID(ventaPostDTO.TipoComprobanteID).SingleOrDefault();
        //    //Pago pago = _pagoRepo.GetByID(ventaPostDTO.PagoID).SingleOrDefault();

        //    Venta venta = new Venta()
        //    {
        //        FechaVenta = DateTime.UtcNow,
        //        Vendedor = vendedor,
        //        Pago = null,
        //        Cliente = cliente,
        //        TipoComprobante = null,
        //        PuntoDeVenta = ptoVenta,
        //        Sucursal = sucursal,
        //        Importe = 0
        //    };

        //    _ventaRepo.AddObject(venta);
        //    return (venta.Id);
        //}


        //public Venta GetVentaById(int id)
        //{
        //    Venta venta = _ventaRepo.GetByID(id).AsQueryable()
        //        .Include(x => x.Sucursal)
        //        .Include(x => x.Vendedor)
        //        .Include(x => x.Pago)
        //        .Include(x => x.Pago.TipoPago)
        //        .Include(x => x.Cliente)
        //        .Include(x => x.TipoComprobante)
        //        .Include(x => x.PuntoDeVenta)
        //        .Include(x => x.PuntoDeVenta.Sucursal)
        //        .Include(x => x.PuntoDeVenta.Sucursal.Tienda)
        //        .SingleOrDefault();

        //    venta.LineasDeVenta = _lineaVentaRepo.GetBy(x => x.VentaID == venta.Id)
        //        .AsQueryable()
        //        .Include(x => x.Stock)
        //        .Include(x => x.Stock.Articulo)
        //        .Include(x => x.Stock.Articulo.Marca)
        //        .Include(x => x.Stock.Articulo.Categoria)
        //        .Include(x => x.Stock.Color)
        //        .Include(x => x.Stock.Talle)
        //        .Include(x => x.Stock.Talle.TipoTalle)
        //        .ToList();
        //    return venta;
        //}

        //public List<Venta> GetVentas()
        //{
        //    return _ventaRepo.GetAll().AsQueryable()
        //        .Include(x => x.Sucursal)
        //        .Include(x => x.Vendedor)
        //        .Include(x => x.Pago)
        //        .Include(x => x.Pago.TipoPago)
        //        .Include(x => x.Cliente)
        //        .Include(x => x.TipoComprobante)
        //        .Include(x => x.PuntoDeVenta)
        //        .Include(x => x.PuntoDeVenta.Sucursal)
        //        .Include(x => x.PuntoDeVenta.Sucursal.Tienda)
        //        .ToList();
        //}

    }
}
