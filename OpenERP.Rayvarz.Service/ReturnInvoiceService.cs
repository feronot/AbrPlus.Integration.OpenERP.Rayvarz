using AbrPlus.Integration.OpenERP.Api.DataContracts;
using Microsoft.Extensions.Logging;
using System;

namespace AbrPlus.Integration.OpenERP.Rayvarz.Service
{
    public class ReturnInvoiceService : IReturnInvoiceService
    {
        private readonly IRayvarzCompanyService _rayvarzCompanyService;
        private readonly ILogger<ReturnInvoiceService> _logger;

        public ReturnInvoiceService(IRayvarzCompanyService rayvarzCompanyService,
                                    ILogger<ReturnInvoiceService> logger)
        {
            _rayvarzCompanyService = rayvarzCompanyService;
            _logger = logger;
        }

        public string[] GetAllIds()
        {
            throw new NotImplementedException();
        }

        public InvoiceBundle GetBundle(string key)
        {
            throw new NotImplementedException();
        }

        public ChangeInfo GetChanges(string lastTrackedVersionStamp)
        {
            throw new NotImplementedException();
        }

        public bool Save(InvoiceBundle item)
        {
            throw new NotImplementedException();
        }

        public void SetTrackingStatus(bool enabled)
        {

        }

        public bool SyncWithCrmObjectTypeCode()
        {
            return false;
        }

        public bool Validate(InvoiceBundle item)
        {
            throw new NotImplementedException();
        }
    }
}
