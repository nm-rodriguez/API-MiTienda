using MiTienda.Domain.Contracts;
using MiTienda.Domain.Utilidades;

namespace MiTienda.Domain.Entities
{
    public class Venta : EntidadPersistible, IVenta
    {
        public Sucursal Sucursal { get; set; }

        public DateTime FechaVenta { get; set; }

        public Vendedor Vendedor { get; set; }

        public Pago Pago { get; set; }

        public Cliente Cliente { get; set; }

        public TipoComprobante TipoComprobante { get; set; }

        public PuntoDeVenta PuntoDeVenta { get; set; }

        public List<LineaDeVenta>? LineaDeVenta { get; set; }//sacar el nulleable despues que cree lineas de venta para probar
        public double? Importe { get; set; }


        public void GetTotal(List<LineaDeVenta> detallesVenta)
        {
            if (detallesVenta is null)
            {
                Importe = 0;
                return;
            }

            foreach (LineaDeVenta item in detallesVenta)
            {
                Importe += (double)(item.Cantidad * item.Stock.Articulo.PrecioFinal);
            }

        }

        public void AgregarArticulos(Articulo articulo)
        {
            throw new NotImplementedException();
        }

        public void AgregarMetodoDePago(TipoPago metodoPago)
        {
            throw new NotImplementedException();
        }

        public void asociarCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public void AsociarTipoComprobante(TipoComprobante comprobante)
        {
            throw new NotImplementedException();
        }

        public void ConfirmarVenta(Venta venta)
        {
            throw new NotImplementedException();
        }

        public void RealizarPagoEfectivo(Pago pagoEfectivo)
        {
            throw new NotImplementedException();
        }

        public void RealizarPagoTarjeta(Pago pagoTarjeta)
        {
            throw new NotImplementedException();
        }

    }
}
