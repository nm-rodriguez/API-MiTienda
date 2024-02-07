
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiTienda.Application.Contracts
{
    public interface IManageArticuloService
    {
        void CreateArticulo(string idArticulo);
        void UpdateArticulo(string idArticulo);
        void DeleteArticulo(string idArticulo);
    }
}
