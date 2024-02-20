using Microsoft.EntityFrameworkCore;
using MiTienda.Application.Contracts;
using MiTienda.Application.DTOs;
using MiTienda.DataAccess.Repositories;
using MiTienda.Domain.Contracts;
using MiTienda.Domain.Entities;

namespace MiTienda.Application.Services
{
    public class ClienteManageService : IManageClienteService
    {
        private IRepository<Cliente> _clienteRepo;

        public ClienteManageService(IRepository<Cliente> clienteRepo)
        {
            _clienteRepo = clienteRepo;

        }
        public List<ClienteDTO> GetClientes()
        {
            List<ClienteDTO> clientes = new List<ClienteDTO>();

            foreach (Cliente cliente in _clienteRepo.GetAll().AsQueryable().Include(x => x.CondicionTributaria))
            {
                ClienteDTO ClienteDTO = new ClienteDTO(cliente);
                clientes.Add(ClienteDTO);
            }
            return clientes;
        }

        public ClienteDTO GetClienteByIdOrDni(int idordni)
        {
            ClienteDTO cliente = new ClienteDTO(_clienteRepo.GetBy(c => c.Id == idordni || c.Dni == idordni).AsQueryable().Include(x => x.CondicionTributaria).SingleOrDefault());
            return (cliente == null) ? null : cliente;

        }

        //public string CreateCliente(ClienteDTO NewCliente)
        //{
        //    try
        //    {
        //        if (NewCliente == null)
        //            throw new Exception("No se puede agregar un cliente vacio");

        //        bool validateExistence = _clienteRepo.GetAll().Any(c => c.Descripcion.ToLower() == NewCliente.Descripcion.ToLower());

        //        if (validateExistence)
        //        {
        //            throw new Exception("El cliente que desea dar de alta ya existe");
        //        }
        //        else
        //        {
        //            Cliente cliente = NewCliente.CastearACliente();
        //            _clienteRepo.AddObject(cliente);
        //            return $"Cliente creado correctamente ID: {cliente.Id} , NOMBRE: {cliente.Descripcion}";
        //            //return $"Cliente creado correctamente ID:";

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }

        //}

        //public string UpdateCliente(ClienteDTO ClienteDTO)
        //{
        //    try
        //    {
                
        //        Cliente existingCliente = _clienteRepo.GetByID(ClienteDTO.IdCliente).FirstOrDefault(); //

        //        if (existingCliente == null)
        //        {
        //            throw new Exception($"No se encontró ningún cliente con ID: {ClienteDTO.IdCliente}");
        //        }
        //        existingCliente.Descripcion = ClienteDTO.Descripcion;
        //        _clienteRepo.Update(existingCliente);

        //        return $"Cliente ID: {existingCliente.Id} actualizado correctamente";
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception($"Error al actualizar el cliente: {ex.Message}");
        //    }
        //}

        public ClienteDTO GetClientesByNombreOrCuil(string NombreoCuil)
        {
            throw new NotImplementedException();
        }

        public string DeleteCliente(ClienteDTO cliente)
        {
            throw new NotImplementedException();
        }

        public string UpdateCliente(ClienteDTO cliente)
        {
            throw new NotImplementedException();
        }

        public string CreateCliente(ClienteDTO cliente)
        {
            throw new NotImplementedException();
        }



        //public string CreateCliente(string NewCliente)
        //{
        //    try
        //    {
        //        if (NewCliente == null)
        //            throw new Exception("No se puede agregar un cliente vacio");

        //        bool validateExistence = _clienteRepo.GetAll().Any(c => c.Descripcion.ToLower() == NewCliente.ToLower());

        //        if (validateExistence)
        //        {
        //            throw new Exception("El cliente que desea dar de alta ya existe");
        //        }
        //        else
        //        {
        //            Cliente cliente = new Cliente { Descripcion = NewCliente };
        //            _clienteRepo.AddObject(cliente);
        //            return $"Cliente creado correctamente ID: {cliente.Id} , NOMBRE: {cliente.Descripcion}";
        //            //return $"Cliente creado correctamente ID:";

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }

        //}
    }
}
