using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MiTienda.DataAccess.PersistenceEntities
{
    public class ClienteDB
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCliente { get; set; }
        public int Dni { get; set; }
        public string Cuil { get; set; }
        public string Apellido{ get; set; }
        public string Nombre{ get; set; }
        [ForeignKey("IdCondicionTributaria")]
        public CondicionTributariaDB? ConTributaria { get; set; }

        private void AsociarCliente()
        {
            throw new NotImplementedException();
        }
    }
}
