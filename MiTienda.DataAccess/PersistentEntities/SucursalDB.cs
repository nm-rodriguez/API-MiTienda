using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MiTienda.DataAccess.PersistenceEntities
{
    public class SucursalDB
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdSucursal { get; set; }
        public int Numero { get; set; }
        public string Nombre { get; set; }
        
        [ForeignKey("IdTienda")]
        public TiendaDB Tienda { get; set; }


        private int ObtenerCantidadStock()
        {
            throw new NotImplementedException();
        }
    }
}
