namespace MiTienda.Domain.Entities
{
    public class Venta
    {
        public DateTime FechaVenta { get; set; }
        public PuntoDeVenta PuntoDeVenta { get; set; }
        public List<LineaDeVenta> LineaDeVenta { get; set; }
        public Vendedor Vendedor { get; set; }
        public Pago Pago { get; set; }
        public Cliente Cliente { get; set; }

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
