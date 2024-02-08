using MiTienda.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiTienda.Application.DTOs
{
    public class ArticuloDTO
    {
        [Required] public string CodigoBarras { get; set; }
        [Required] public string Descripcion { get; set; }
        [Required] public double Costo { get; set; }
        [Required] public double MargenGanancia { get; set; }
        [Required] public double? PrecioFinal { get; set; }
        [Required] public double? NetoGravado { get; set; }
        [Required] public double PorcentajeIVA { get; set; }
        [Required] public int IdMarca { get; set; }
        [Required] public int IdCategoria { get; set; }

        public ArticuloDTO()
        {
        }
    }
}

