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

        public void CreateArticulo(Articulo articulo)
        {
            _articuloRepo.AddObject(articulo);
        }
        public void UpdateArticulo(Articulo articulo)
        {
            _articuloRepo.Update(articulo);
        }
        public void DeleteArticulo(int idArticulo)
        {
            _articuloRepo.DeleteByID(idArticulo);
        }

        public void SaveArticulo()
        {
            _articuloRepo.SaveChanges();
        }
    }
}
