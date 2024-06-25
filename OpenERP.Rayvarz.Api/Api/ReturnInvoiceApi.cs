using AbrPlus.Integration.OpenERP.Api.Contracts;
using AbrPlus.Integration.OpenERP.Api.DataContracts;
using AbrPlus.Integration.OpenERP.Rayvarz.Service;
using SeptaKit.DI;

namespace AbrPlus.Integration.OpenERP.Rayvarz.Api.Api
{
    public class ReturnInvoiceApi : IReturnInvoiceApi, IApi
    {
        private readonly IReturnInvoiceService _returnInvoiceService;
        public ReturnInvoiceApi(IReturnInvoiceService returnInvoiceService)
        {
            _returnInvoiceService = returnInvoiceService;
        }

        public string[] GetAllIds(int? companyId)
        {
            return _returnInvoiceService.GetAllIds();
        }
        public InvoiceBundle GetBundle(string key, int? companyId)
        {
            return _returnInvoiceService.GetBundle(key);
        }
        public ChangeInfo GetChanges(string lastTrackedVersion, int? companyId)
        {
            return _returnInvoiceService.GetChanges(lastTrackedVersion);
        }
        public bool Save(InvoiceBundle item, int? companyId)
        {
            return _returnInvoiceService.Save(item);
        }
        public void SetTrackingStatus(bool enabled, int? companyId)
        {
            _returnInvoiceService.SetTrackingStatus(enabled);
        }
        public bool SyncWithCrmObjectTypeCode(int companyId)
        {
            return _returnInvoiceService.SyncWithCrmObjectTypeCode();
        }
        public bool Validate(InvoiceBundle item)
        {
            return _returnInvoiceService.Validate(item);
        }
    }
}
