using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiTienda.Application.DTOs
{
    public class LineaVentaDTO
    {
        public LineaVentaDTO(int cantidad, int idStock)
        {
            Cantidad = cantidad;
            this.idStock = idStock;
        }

        public int Cantidad { get; set; }
        public int idStock { get; set; }


    }
}
