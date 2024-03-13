using MiTienda.Application.DTOs;
using MiTienda.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiTienda.Application.Contracts
{
    public interface IManagePagoService
    {
        Pago GetPagoById(int id);
        List<Pago> GetPagos();
        //List<Pago> GetPagosBySucursal(int idSucursal);
        //List<Pago> GetPagosByEmpleado(int idEmpleado);
        Pago CrearPago(PagoPostDTO pago);
        //string UpdateImportePago(int idPago);
        //string UpdateClientePago(int idPago, int idCliente);


    }
}
