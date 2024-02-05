using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MiTienda.DataAccess.PersistenceEntities;
using MiTienda.Domain.Contracts;

namespace MiTienda.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbSet<T> CreateSet { get; set; }
        
        //public DbSet<StockDB> Stocks { get; set; }
        public IEnumerable<T> GetAll()
        {
            return CreateSet;//faltan includes
        }
        
        public void AddObject(T item)
        {
            throw new NotImplementedException();
        }

        public void DeleteByID(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteObject(T item)
        {
            throw new NotImplementedException();
        }

        public void DropChanges()
        {
            throw new NotImplementedException();
        }

      

        public IEnumerable<T> GetBy(Expression<Func<T, bool>> filtro)
        {
            throw new NotImplementedException();
        }

        public T GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Refresh(T item)
        {
            throw new NotImplementedException();
        }

        public void Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}
