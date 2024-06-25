using AbrPlus.Integration.OpenERP.Api.DataContracts;

namespace AbrPlus.Integration.OpenERP.Rayvarz.Service
{
    public interface IReturnInvoiceService
    {
        string[] GetAllIds();
        InvoiceBundle GetBundle(string key);
        ChangeInfo GetChanges(string lastTrackedVersionStamp);
        bool Save(InvoiceBundle item);
        void SetTrackingStatus(bool enabled);
        bool SyncWithCrmObjectTypeCode();
        bool Validate(InvoiceBundle item);
    }
    public interface ISlsReturnInvoiceService : IReturnInvoiceService
    {
    }
    public interface IRmsReturnInvoiceService : IReturnInvoiceService
    {
    }
}
