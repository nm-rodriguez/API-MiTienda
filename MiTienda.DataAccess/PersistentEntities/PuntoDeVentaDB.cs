using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MiTienda.DataAccess.PersistenceEntities
{
    public class PuntoDeVentaDB
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPuntoDeVenta { get; set; }
        public int Numero { get; set; }
        [ForeignKey("IdSucursal")]
        public SucursalDB Sucursal { get; set; }

        private void AgregarVenta()
        {
            throw new NotImplementedException();
        }
    
    }
}
