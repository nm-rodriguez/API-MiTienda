﻿using MiTienda.Application.DTOs;
using MiTienda.Domain.Entities;
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
        int CrearVenta(VentaPostDTO venta);
        
    }
}
