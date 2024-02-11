
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
        List<ArticuloDTO> GetArticulos();
        ArticuloDTO GetArticulo(int id);
        void DeleteArticulo(int idArticulo);
        void UpdateArticulo(Articulo articulo);
        void CreateArticulo(Articulo articulo);

    }
}
