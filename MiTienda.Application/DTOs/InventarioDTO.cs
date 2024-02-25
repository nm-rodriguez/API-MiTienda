using MiTienda.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiTienda.Application.DTOs
{
    public class CrearInventarioDTO
    {
        public int IdInventario { get; set; }
        public int Cantidad { get; set; }

        public int IdStock { get; set; }
        public int IdSucursal { get; set; }

        public CrearInventarioDTO(){}
        public CrearInventarioDTO(Inventario inventario)
        {
            IdInventario = inventario.Id;
            Cantidad = inventario.Cantidad;
            IdStock = inventario.Stock.Id;
            IdSucursal = inventario.Sucursal.Id;
        }


        public Inventario CastearAInventario(Stock stock , Sucursal sucursal)
        {
            Inventario inventario = new Inventario();
            inventario.Id = IdInventario;
            inventario.Cantidad = Cantidad;
            inventario.Stock = stock;
            inventario.Sucursal = sucursal;

            return inventario;
        }

    }

    //public class ReturnInventarioDTO
    //{
    //    public ReturnInventarioDTO()
    //    {

    //    }
    //    public ReturnInventarioDTO(Inventario inventario)
    //    {
    //        IdInventario = inventario.Id;
    //        Cantidad = inventario.Cantidad;

    //        IdStock = inventario.Stock.Id;
    //        idSucursal = inventario.Sucursal.Id;
    //    }

     


    //    public Inventario CastearAInventario(Stock stock, Sucursal sucursal)
    //    {
    //        Inventario inventario = new Inventario();
    //        inventario.Id = IdInventario;
    //        inventario.Cantidad = Cantidad;
    //        inventario.Stock = stock;
    //        inventario.Sucursal = sucursal;

    //        return inventario;
    //    }

    //}
}
