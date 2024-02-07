using MiTienda.Domain.Utilidades;

namespace MiTienda.Domain.Entities
{
    public class Venta : EntidadPersistible
    {
        public Sucursal Sucursal { get; set; }
        
        public DateTime FechaVenta { get; set; }
        
        public Vendedor Vendedor { get; set; }
        
        public Pago Pago { get; set; }
       
        public Cliente Cliente { get; set; }
        
        public TipoComprobante TipoComprobante { get; set; }
        
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
