using AbrPlus.Integration.OpenERP.Api.Contracts;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System;
using AbrPlus.Integration.OpenERP.Api.DataContracts;

namespace AbrPlus.Integration.OpenERP.Rayvarz.Service
{
    public class InventoryService : IInventoryService
    {
        private readonly IRayvarzCompanyService _rayvarzCompanyService;
        private readonly ILogger<InventoryService> _logger;

        public InventoryService(IRayvarzCompanyService rayvarzCompanyService,
                                ILogger<InventoryService> logger)
        {
            _rayvarzCompanyService = rayvarzCompanyService;
            _logger = logger;
        }
        public List<RemainingStock> GetRemainingStock(string productCode)
        {
            var setting = _rayvarzCompanyService.GetCompanyConfig();

            throw new NotImplementedException();
        }
    }
}
