using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MiTienda.DataAccess.PersistenceEntities
{
    public class CondicionTributariaDB
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCondicionTributaria { get; set; }
        [MaxLength(2)]
        public string Abreviatura { get; set; }
        public string Descripcion { get; set; }
    }
}