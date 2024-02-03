using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MiTienda.DataAccess.PersistenceEntities
{
    public class LineaDeVentaDB
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdLineaDeVenta { get; set; }
        public int Cantidad { get; set; }
        [ForeignKey("IdStock")]
        public StockDB Stock { get; set; }
        [ForeignKey("IdVenta")]
        public VentaDB Venta { get; set; }
       
        
        private void Crear()
        {
            throw new NotImplementedException();

        }
        private double GetPrecio()
        {
            throw new NotImplementedException();
        }
    }
}
