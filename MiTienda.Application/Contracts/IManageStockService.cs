
using MiTienda.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiTienda.Application.Contracts
{
    public interface IManageStockService
    {
        string CreateStock(StockDTO stockDTO);
        void UpdateStock(StockDTO stockDTO);
        void DeleteStock(StockDTO stockDTO);
    }
}
