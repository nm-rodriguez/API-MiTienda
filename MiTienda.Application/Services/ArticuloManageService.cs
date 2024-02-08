using MiTienda.Application.Contracts;
using MiTienda.Application.DTOs;
using MiTienda.Domain.Contracts;
using MiTienda.Domain.Entities;

namespace MiTienda.Application.Services
{
    public class ArticuloManageService : IManageArticuloService
    {
        private  IRepository<Articulo> _articuloRepo;

        public ArticuloManageService(IRepository<Articulo> articuloRepo)
        {
            _articuloRepo = articuloRepo;
        }
        public void CreateArticulo(ArticuloDTO newArticulo)
        {
            throw new NotImplementedException();
        }
        public void DeleteArticulo(int idArticulo)
        {
            throw new NotImplementedException();
        }
        public void UpdateArticulo(ArticuloDTO articulo)
        {
            throw new NotImplementedException();
        }

        
    }
}
