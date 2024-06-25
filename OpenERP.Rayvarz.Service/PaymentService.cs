using AbrPlus.Integration.OpenERP.Api.DataContracts;
using Microsoft.Extensions.Logging;
using System;

namespace AbrPlus.Integration.OpenERP.Rayvarz.Service
{
    public class PaymentService : IPaymentService
    {
        private readonly IRayvarzCompanyService _rayvarzCompanyService;
        private readonly ILogger<PaymentService> _logger;

        public PaymentService(IRayvarzCompanyService rayvarzCompanyService,
                              ILogger<PaymentService> logger)
        {
            _rayvarzCompanyService = rayvarzCompanyService;
            _logger = logger;
        }
        public PaymentBundle GetBundle(string key)
        {
            throw new NotImplementedException();
        }

        public ChangeInfo GetChanges(string lastTrackedVersionStamp)
        {
            throw new NotImplementedException();
        }

        public bool Save(PaymentBundle item)
        {
            throw new NotImplementedException();
        }
        public bool Validate(PaymentBundle item)
        {
            throw new NotImplementedException();
        }
        public string[] GetAllIds()
        {
            throw new NotImplementedException();
        }
        public void SetTrackingStatus(bool enabled)
        {

        }
    }
}
