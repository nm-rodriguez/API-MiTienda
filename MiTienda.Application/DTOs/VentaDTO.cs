using MiTienda.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiTienda.Application.DTOs
{
    public class VentaDTO
    {
        public int SucursalID { get; set; }
        public string SucursalNombre { get; set; }

        public string FechaVenta { get; set; }

        public int VendedorID { get; set; }
        public string VendedorNombre { get; set; }

        public double PagoMonto { get; set; }
        public string PagoMoneda { get; set; }
        public string PagoTipoPagoDescripcion { get; set; }

        public int ClienteDNI { get; set; }
        public string ClienteNombre { get; set; }

        public string TipoComprobante { get; set; }

        public int PuntoDeVenta { get; set; }

        public List <LineaVentaDTO> DetallesVenta { get; set; }

        public VentaDTO(Venta venta)
        {
            SucursalID = venta.Sucursal.Id;
            SucursalNombre = venta.Sucursal.Nombre;
            FechaVenta = venta.FechaVenta.ToString();
            VendedorID = venta.Vendedor.Id;
            VendedorNombre = venta.Vendedor.Nombre;
            PagoMonto = venta.Pago.Monto;
            PagoMoneda = venta.Pago.Moneda;
            PagoTipoPagoDescripcion = venta.Pago.TipoPago.Descripcion;
            ClienteDNI = venta.Cliente.Dni;
            ClienteNombre = venta.Cliente.Nombre;
            TipoComprobante = venta.TipoComprobante.Descripcion;
            PuntoDeVenta = venta.PuntoDeVenta.Numero;
        }

        public Venta CastearAVenta(DateTime fechaVenta,Vendedor vendedor,Pago pago,Cliente cliente,TipoComprobante tipoComprobante,PuntoDeVenta puntoVenta, Sucursal sucursal)
        {
            Venta venta = new Venta() { };

            return venta;
        }


    }

    
}
