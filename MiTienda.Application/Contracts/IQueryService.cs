using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MiTienda.Application.Contracts
{
    public interface IQueryService<T>
    {
        IEnumerable<T> GetAll();
        IQueryable<T> GetAllWithRelatedData();
        IEnumerable<T> GetBy(Expression<Func<T,bool>> filter);

    }
}
