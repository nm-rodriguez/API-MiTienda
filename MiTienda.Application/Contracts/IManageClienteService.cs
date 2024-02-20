
using MiTienda.Application.DTOs;
using MiTienda.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiTienda.Application.Contracts
{
    public interface IManageClienteService
    {
        List<ClienteDTO> GetClientes();
        public ClienteDTO GetClienteByIdOrDni(int IdOrDni);
        public ClienteDTO GetClientesByNombreOrCuil(string NombreoCuil);
        string UpdateCliente(ClienteDTO cliente);
        string CreateCliente(ClienteDTO cliente);
        string DeleteCliente(ClienteDTO cliente);

    }
}
