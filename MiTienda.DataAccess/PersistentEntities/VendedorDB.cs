using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiTienda.DataAccess.PersistenceEntities
{
    public class VendedorDB
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdVendedor { get; set; }
        public int Legajo { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string Usuario { get; set; }
        public string Contrasenia { get; set; }
        [ForeignKey("IdSucursal")]
        public SucursalDB? Sucursal { get; set; }
    }
}
