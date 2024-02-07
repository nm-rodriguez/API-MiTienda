using MiTienda.Domain.Enums;
using MiTienda.Domain.Utilidades;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiTienda.Domain.Entities
{
    public class Venta : EntidadPersistible
    {
        [ForeignKey("IdSucursal")]
        public Sucursal Sucursal { get; set; }
        
        public DateTime FechaVenta { get; set; }
        
        [ForeignKey("IdVendedor")]
        public Vendedor? Vendedor { get; set; }
        
        [ForeignKey("IdPago")]
        public Pago? Pago { get; set; }
        
        [ForeignKey("IdCliente")]
        public Cliente? Cliente { get; set; }
        
        [ForeignKey("IdTipoComprobante")]
        public TipoComprobante? TipoComprobante { get; set; }
        
        [ForeignKey("IdPuntoDeVenta")]
        public PuntoDeVenta PuntoDeVenta { get; set; }


        private double GetTotal()
        {
            throw new NotImplementedException();
        }
        private void AgregarArticulos()
        {
            throw new NotImplementedException();
        }
        private void AgregarMetodoDePago()
        {
            throw new NotImplementedException();
        }
        private void RealizarPagoEfectivo()
        {
            throw new NotImplementedException();
        }
        private void RealizarPagoTarjeta()
        {
            throw new NotImplementedException();
        }
        private void ConfirmarVenta()
        {
            throw new NotImplementedException();
        }
        private void AsociarTipoComprobante()
        {
            throw new NotImplementedException();
        }
        private void asociarCliente()
        {
            throw new NotImplementedException();
        }





    }
}
