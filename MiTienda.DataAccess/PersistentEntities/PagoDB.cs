using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MiTienda.DataAccess.PersistenceEntities
{
    public class PagoDB
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPago { get; set; }
        public DateTime FechaPago { get; set; }
        public double Monto { get; set; }
        [ForeignKey("IdTipoPago")]
        public TipoPagoDB? TipoPago { get; set; }


        private void RealizarPago()
        {
            throw new NotImplementedException();
        }
        //private void AgregarTarjeta()
        //{
        //    throw new NotImplementedException();
        //}
        //private void AgregarPago()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
