using MiTienda.Domain.Entities;
using MiTienda.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MiTienda.DataAccess.PersistenceEntities
{
    public class TipoTalleDB
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTipoTalle { get; set; }
        public string Descipcion { get; set; }
    }




}
