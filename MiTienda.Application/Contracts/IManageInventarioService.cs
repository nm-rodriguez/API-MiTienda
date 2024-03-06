
using MiTienda.Application.DTOs;
using MiTienda.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiTienda.Application.Contracts
{
    public interface IManageInventarioService
    {
        List<ReturnInventarioDTO> GetInvetarios(int IdSucursal);
        List<ReturnInventarioDTO> GetInventarioById(int IdInventario);
        List<ReturnInventarioDTO> GetInventarioByCodigoBarra(string CodigoBarra);
        //string UpdateCliente(ClienteDTO cliente);
        //string CreateCliente(ClienteDTO cliente);
        //string DeleteCliente(int Id);

    }
}
