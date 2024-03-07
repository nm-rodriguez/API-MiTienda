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

        public VentaDTO(int sucursalID, string sucursalNombre, string fechaVenta, int vendedorID, string vendedorNombre, double pagoMonto, string pagoMoneda, string pagoTipoPagoDescripcion, int clienteDNI, string clienteNombre, string tipoComprobante, int puntoDeVenta)
        {
            SucursalID = sucursalID;
            SucursalNombre = sucursalNombre;
            FechaVenta = fechaVenta;
            VendedorID = vendedorID;
            VendedorNombre = vendedorNombre;
            PagoMonto = pagoMonto;
            PagoMoneda = pagoMoneda;
            PagoTipoPagoDescripcion = pagoTipoPagoDescripcion;
            ClienteDNI = clienteDNI;
            ClienteNombre = clienteNombre;
            TipoComprobante = tipoComprobante;
            PuntoDeVenta = puntoDeVenta;
        }

        public Venta CastearAVenta(DateTime fechaVenta,Vendedor vendedor,Pago pago,Cliente cliente,TipoComprobante tipoComprobante,PuntoDeVenta puntoVenta, Sucursal sucursal)
        {
            Venta venta = new Venta() { };

            return venta;
        }


    }

    
}
