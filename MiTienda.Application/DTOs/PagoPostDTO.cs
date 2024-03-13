using MiTienda.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiTienda.Application.DTOs
{
    public class PagoPostDTO
    {
        public int idVenta { get; set; }
        public int idTipoPago { get; set; }
        public double Monto { get; set; }
        public int? idTipoTarjeta { get; set; }
        public string? token { get; set; }
    }
}
