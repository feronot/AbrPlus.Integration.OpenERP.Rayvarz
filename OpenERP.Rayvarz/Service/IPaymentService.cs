using AbrPlus.Integration.OpenERP.Api.DataContracts;

namespace AbrPlus.Integration.OpenERP.Rayvarz.Service
{
    public interface IPaymentService
    {
        string[] GetAllIds();
        PaymentBundle GetBundle(string key);
        ChangeInfo GetChanges(string lastTrackedVersionStamp);
        bool Save(PaymentBundle item);
        void SetTrackingStatus(bool enabled);
        bool Validate(PaymentBundle item);
    }
}
