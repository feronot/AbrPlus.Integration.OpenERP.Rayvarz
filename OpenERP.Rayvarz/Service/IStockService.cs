using AbrPlus.Integration.OpenERP.Rayvarz.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbrPlus.Integration.OpenERP.Rayvarz.Service
{
    public interface IStockService
    {
        List<StockQuantity> GetItemQuantityInAllStock(string itemCode);
    }
}
