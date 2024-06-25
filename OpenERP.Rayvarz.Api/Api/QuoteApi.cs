using AbrPlus.Integration.OpenERP.Api.Contracts;
using AbrPlus.Integration.OpenERP.Api.DataContracts;
using AbrPlus.Integration.OpenERP.Rayvarz.Service;
using SeptaKit.DI;

namespace AbrPlus.Integration.OpenERP.Rayvarz.Api.Api
{
    public class QuoteApi : IQuoteApi, IApi
    {
        private readonly IQuoteService _quoteService;

        public QuoteApi(IQuoteService quoteService)
        {
            _quoteService = quoteService;
        }

        public string[] GetAllIds(int? companyId)
        {
            return _quoteService.GetAllIds();
        }
        public InvoiceBundle GetBundle(string key, int? companyId)
        {
            return _quoteService.GetBundle(key);
        }
        public ChangeInfo GetChanges(string lastTrackedVersion, int? companyId)
        {
            return _quoteService.GetChanges(lastTrackedVersion);
        }
        public bool Save(InvoiceBundle item, int? companyId)
        {
            return _quoteService.Save(item);
        }
        public void SetTrackingStatus(bool enabled, int? companyId)
        {
            _quoteService.SetTrackingStatus(enabled);
        }
        public bool SyncWithCrmObjectTypeCode(int companyId)
        {
            return _quoteService.SyncWithCrmObjectTypeCode();
        }
        public bool Validate(InvoiceBundle item)
        {
            return _quoteService.Validate(item);
        }
    }
}
