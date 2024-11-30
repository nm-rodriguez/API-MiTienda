using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiTienda.Application.DTOs
{
    public class UserCredentialsDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Legajo { get; set; }
        public int SucursalId { get; set; }
    }

    public class UserLoginDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class UserWithTokenDTO
    {
        public string Token { get; set; }

        public string Expiracion { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Legajo { get; set; }
        public string UserID { get; set; }
        public int SucursalId { get; set; }
    }

    public class UserLogged
    {
        public string Token { get; set; }
        public string Expiracion { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Legajo { get; set; }
        public int Sucursal { get; set; }
        public string NombreSucursal { get; set; }
    }

}
