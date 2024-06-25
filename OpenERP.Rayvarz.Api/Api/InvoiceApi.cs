using AbrPlus.Integration.OpenERP.Api.Contracts;
using AbrPlus.Integration.OpenERP.Api.DataContracts;
using AbrPlus.Integration.OpenERP.Rayvarz.Service;
using SeptaKit.DI;

namespace AbrPlus.Integration.OpenERP.Rayvarz.Api.Api
{
    public class InvoiceApi : IInvoiceApi, IApi
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceApi(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        public string[] GetAllIds(int? companyId)
        {
            return _invoiceService.GetAllIds();
        }
        public InvoiceBundle GetBundle(string key, int? companyId)
        {
            return _invoiceService.GetBundle(key);
        }
        public ChangeInfo GetChanges(string lastTrackedVersion, int? companyId)
        {
            return _invoiceService.GetChanges(lastTrackedVersion);
        }
        public bool Save(InvoiceBundle item, int? companyId)
        {
            return _invoiceService.Save(item);
        }
        public void SetTrackingStatus(bool enabled, int? companyId)
        {
            _invoiceService.SetTrackingStatus(enabled);
        }
        public bool SyncWithCrmObjectTypeCode(int companyId)
        {
            return _invoiceService.SyncWithCrmObjectTypeCode();
        }
        public bool Validate(InvoiceBundle item)
        {
            return _invoiceService.Validate(item);
        }
    }
}
