using MiTienda.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiTienda.Application.Contracts
{
    public interface IManageVentaService
    {
        List<VentaDTO> GetVentas();
        List<VentaDTO> GetVentasBySucursal(int idSucursal);
        List<VentaDTO> GetVentasByEmpleado(int idEmpleado);
        string CrearVenta(VentaPostDTO venta);
        
    }
}
