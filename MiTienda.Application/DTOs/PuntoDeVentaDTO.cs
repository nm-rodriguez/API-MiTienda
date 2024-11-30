using MiTienda.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiTienda.Application.DTOs
{
    public class PuntoDeVentaDTO
    {
        public PuntoDeVentaDTO()
        {

        }
        public PuntoDeVentaDTO(PuntoDeVenta PuntoDeVenta)
        {
            IdPuntoDeVenta = PuntoDeVenta.Id;
            Numero = PuntoDeVenta.Numero;
            SucursalId = PuntoDeVenta.Sucursal.Id;

        }

        public int IdPuntoDeVenta { get; set; }
        public int Numero { get; set; }
        public int SucursalId { get; set; }

        public PuntoDeVenta CastearAPuntoDeVenta(Sucursal suc)
        {
            PuntoDeVenta PuntoDeVenta = new PuntoDeVenta();
            PuntoDeVenta.Numero = Numero;
            PuntoDeVenta.Sucursal = suc;
            return PuntoDeVenta;
        }
    }
}
