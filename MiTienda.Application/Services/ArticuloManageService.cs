using Microsoft.EntityFrameworkCore;
using MiTienda.Application.Contracts;
using MiTienda.Application.DTOs;
using MiTienda.Domain.Contracts;
using MiTienda.Domain.Entities;

namespace MiTienda.Application.Services
{
    public class ArticuloManageService : IManageArticuloService
    {
        private  IRepository<Articulo> _articuloRepo;
        private readonly IQueryService<Marca> _queryServiceMarca;
        private readonly IQueryService<Categoria> _queryServiceCategoria;

        public ArticuloManageService(IRepository<Articulo> articuloRepo, IQueryService<Marca> queryServiceMarca, IQueryService<Categoria> queryServiceCategoria)
        {
            _articuloRepo = articuloRepo;
            _queryServiceMarca = queryServiceMarca;
            _queryServiceCategoria = queryServiceCategoria;
        }

        public void CreateArticulo(Articulo art)
        {
            //try
            //{
            //    if (_articuloRepo.GetBy(x => x.Id == art.Id) == null)
            //        throw new Exception();

            //    if (art == null)
            //        throw new Exception();
            //    Articulo articulo = art;
            //    List<Marca> m =  _queryServiceMarca.GetAllWithRelatedData().AsQueryable().Include(a => a.Marca).Include(a => a.Categoria);
            //    articulo.Marca =  _queryServiceMarca.GetAllWithRelatedData().Where(x => x.Id == articulo.Marca.Id).SingleOrDefault();
            //    articulo.Marca =  (Marca)_queryServiceMarca.GetAllWithRelatedData().Where(x => x.Id == articulo.Marca.Id).FirstOrDefault();
            //    articulo.Marca =  (Marca)_queryServiceMarca.GetAllWithRelatedData().Where(x => x.Id == articulo.Marca.Id).SingleOrDefault();
            //    articulo.Categoria =  _queryServiceCategoria.GetBy(x => x.Id == articulo.Categoria.Id).SingleOrDefault();
            //    articulo.PrecioFinal = articulo.Costo * (1 + articulo.MargenGanancia);
            //    articulo.NetoGravado = articulo.Costo * (articulo.MargenGanancia);

            //    _articuloRepo.AddObject(articulo);

            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.ToString());
            //}
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
