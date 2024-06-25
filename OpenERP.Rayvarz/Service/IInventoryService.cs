using AbrPlus.Integration.OpenERP.Api.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbrPlus.Integration.OpenERP.Rayvarz.Service
{
    public interface IInventoryService
    {
        List<RemainingStock> GetRemainingStock(string productCode);
    }
}
