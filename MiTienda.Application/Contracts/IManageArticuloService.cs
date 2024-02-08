
using MiTienda.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiTienda.Application.Contracts
{
    public interface IManageArticuloService
    {
        void CreateArticulo(ArticuloDTO articulo);
        void UpdateArticulo(ArticuloDTO articulo);
        void DeleteArticulo(int idArticulo);
    }
}
