using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiTienda.DataAccess.Contracts
{
    public interface IVentaEF
    {
        DbSet<T> CrearSet<T>() where T : class;
        void SetModificado<T>(T item) where T : class;
        void Refrescar<T>(T item) where T : class;
    }
}
