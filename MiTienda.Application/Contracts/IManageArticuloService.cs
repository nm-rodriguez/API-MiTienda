
using MiTienda.Application.DTOs;
using MiTienda.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiTienda.Application.Contracts
{
    public interface IManageArticuloService
    {
        void CreateArticulo(Articulo articulo);
        void UpdateArticulo(Articulo articulo);
        void DeleteArticulo(int idArticulo);
        void SaveArticulo();
    }
}
