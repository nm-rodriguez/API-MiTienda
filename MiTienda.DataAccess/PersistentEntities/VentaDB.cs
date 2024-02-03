using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MiTienda.DataAccess.PersistenceEntities
{
    public class VentaDB
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdVenta { get; set; }
        public int IdSucursal { get; set; }
        public DateTime FechaVenta { get; set; }
        [ForeignKey("IdVendedor")]
        public VendedorDB? Vendedor { get; set; }
        [ForeignKey("IdPago")]
        public PagoDB? Pago { get; set; }
        [ForeignKey("IdCliente")]
        public ClienteDB? Cliente { get; set; }
        [ForeignKey("IdTipoComprobante")]
        public TipoComprobanteDB? TipoComprobante { get; set; }
        [ForeignKey("IdPuntoDeVenta")]
        public PuntoDeVentaDB PuntoDeVenta { get; set; }

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
