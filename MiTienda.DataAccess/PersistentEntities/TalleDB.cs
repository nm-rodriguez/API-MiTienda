using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MiTienda.DataAccess.PersistenceEntities
{
    public class TalleDB
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTalle { get; set; }
        [ForeignKey("IdTipoTalle")]
        public TipoTalleDB TipoTalle { get; set; }
    }




}
