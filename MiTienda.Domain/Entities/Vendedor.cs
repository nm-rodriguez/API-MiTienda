using MiTienda.Domain.Utilidades;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiTienda.Domain.Entities
{
    public class Vendedor : EntidadPersistible
    {
        public int Legajo { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string Usuario { get; set; }
        public string Contrasenia { get; set; }
        [ForeignKey("IdSucursal")]
        public Sucursal? Sucursal { get; set; }
    }
}
