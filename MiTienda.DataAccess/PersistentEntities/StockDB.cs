using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MiTienda.DataAccess.PersistenceEntities
{
    public class StockDB
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdStock { get; set; }
        public int Cantidad { get; set; }
        [ForeignKey("IdTalle")]
        public TalleDB Talle { get; set; }
        [ForeignKey("IdColor")]
        public ColorDB Color { get; set; }
        [ForeignKey("IdArticulo")]
        public ArticuloDB Articulo { get; set; }

       
    }
}
