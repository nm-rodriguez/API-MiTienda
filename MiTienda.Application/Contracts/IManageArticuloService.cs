
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
        List<ArticuloDTO> GetArticulosByCodigoBarras(string codigo);
        List<ArticuloDTO> GetArticulosByMarca (string? Marca);
        List<ArticuloDTO> GetArticulosByCategoria(string? Categoria);
        List<ArticuloDTO> GetArticulosFiltrados(string? codigoBarra = null, string ? marca = null, string? categoria = null);
        public ArticuloDTO GetArticuloById(int id);
        public ArticuloDTO GetArticuloByCodigoBarras(string codigo);
        string DeleteArticulo(int idArticulo);
        string UpdateArticulo(ArticuloDTO articulo);
        string CreateArticulo(ArticuloDTO articulo);

    }
}
