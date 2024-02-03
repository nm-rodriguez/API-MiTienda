using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MiTienda.DataAccess.PersistenceEntities
{
    public class TiendaDB
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTienda { get; set; }
        public string Cuil { get; set; }
        [ForeignKey("IdCondicionTributaria")]
        public CondicionTributariaDB? ConTributaria { get; set; }

     
    }
}
