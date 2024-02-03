using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiTienda.DataAccess.PersistenceEntities
{
    public class TipoComprobanteDB
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTipoComprobante { get; set; }
        public string Descripcion { get; set; }
    }
}