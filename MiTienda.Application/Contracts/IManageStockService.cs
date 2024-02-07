
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiTienda.Application.Contracts
{
    public interface IManageStockService
    {
        void CreateStock(string idStock);
        void UpdateStock(string idStock);
        void DeleteStock(string idStock);
    }
}
