using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MiTienda.Domain.Contracts
{
    internal interface IRepositorio<T> 
    {
        IEnumerable<T> ObtenerTodos();
        IEnumerable<T> BuscarPor(Expression<Func<T, bool>> filtro);
        T BuscarPorId(int id);
        void Agregar(T item);
        void Eliminar(T item);
        void Eliminar(int id);
        void Modificar(T item);
        void DescartarCambios();
        void Refrescar(T item);
        //void Refrescar(EntidadPersistible item);

        //void ComponerReferencia<T, E>(T item, Expression<Func<T, E>> entidad)
        //    where T : class
        //    where E : class;

        //void ComponerColeccion<T, C>(T item, Expression<Func<T, IEnumerable<C>>> coleccion)
        //    where T : class
        //    where C : class;
    }
}
