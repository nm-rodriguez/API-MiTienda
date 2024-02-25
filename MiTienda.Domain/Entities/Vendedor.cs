using MiTienda.Domain.Utilidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace MiTienda.Domain.Entities
{
    public class Vendedor : EntidadPersistible
    {
        public int Legajo { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string UsuarioId { get; set; }
        public string Contrasenia { get; set; }
        public bool State { get; set; }
        public Sucursal Sucursal { get; set; }
    }
}
