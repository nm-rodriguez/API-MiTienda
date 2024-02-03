using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MiTienda.DataAccess.PersistenceEntities
{
    public class InventarioDB
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdInventario { get; set; }
        public int Cantidad { get; set; }
        [ForeignKey("IdStock")]
        public StockDB Stock { get; set; }
        [ForeignKey("IdSucursal")]
        public SucursalDB Sucursal { get; set; }

     
    }
}
