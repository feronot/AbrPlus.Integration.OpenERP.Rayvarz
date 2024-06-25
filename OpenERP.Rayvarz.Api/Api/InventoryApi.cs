using AbrPlus.Integration.OpenERP.Api.Contracts;
using AbrPlus.Integration.OpenERP.Api.DataContracts;
using AbrPlus.Integration.OpenERP.Rayvarz.Service;
using SeptaKit.DI;
using System;
using System.Collections.Generic;

namespace AbrPlus.Integration.OpenERP.Rayvarz.Api.Api
{
    public class InventoryApi : IInventoryApi, IApi
    {
        private readonly InventoryService _inventoryService;

        public InventoryApi(InventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }
        public List<RemainingStock> GetRemainingStock(string productCode, int companyId)
        {
            return _inventoryService.GetRemainingStock(productCode);
        }
    }
}
