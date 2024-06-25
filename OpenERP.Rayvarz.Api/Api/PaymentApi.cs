using AbrPlus.Integration.OpenERP.Api.Contracts;
using AbrPlus.Integration.OpenERP.Api.DataContracts;
using AbrPlus.Integration.OpenERP.Rayvarz.Service;
using SeptaKit.DI;

namespace AbrPlus.Integration.OpenERP.Rayvarz.Api.Api
{
    public class PaymentApi : IPaymentApi, IApi
    {
        private readonly IPaymentService _paymentService;
        public PaymentApi(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public string[] GetAllIds(int? companyId)
        {
            return _paymentService.GetAllIds();
        }
        public PaymentBundle GetBundle(string key, int? companyId)
        {
            return _paymentService.GetBundle(key);
        }
        public ChangeInfo GetChanges(string lastTrackedVersion, int? companyId)
        {
            return _paymentService.GetChanges(lastTrackedVersion);
        }
        public bool Save(PaymentBundle item, int? companyId)
        {
            return _paymentService.Save(item);
        }
        public void SetTrackingStatus(bool enabled, int? companyId)
        {
            _paymentService.SetTrackingStatus(enabled);
        }
        public bool Validate(PaymentBundle item)
        {
            return _paymentService.Validate(item);
        }
    }
}
