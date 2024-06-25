using AbrPlus.Integration.OpenERP.Api.Contracts;
using AbrPlus.Integration.OpenERP.Api.DataContracts;
using AbrPlus.Integration.OpenERP.Rayvarz.Service;
using SeptaKit.DI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbrPlus.Integration.OpenERP.Rayvarz.Api.Api
{
    public class ReceiptApi : IReceiptApi, IApi
    {
        private readonly IReceiptService _receiptService;
        public ReceiptApi(IReceiptService receiptService)
        {
            _receiptService = receiptService;
        }

        public string[] GetAllIds(int? companyId)
        {
            return _receiptService.GetAllIds();
        }
        public PaymentBundle GetBundle(string key, int? companyId)
        {
            return _receiptService.GetBundle(key);
        }
        public ChangeInfo GetChanges(string lastTrackedVersion, int? companyId)
        {
            return _receiptService.GetChanges(lastTrackedVersion);
        }
        public bool Save(PaymentBundle item, int? companyId)
        {
            return _receiptService.Save(item);
        }
        public void SetTrackingStatus(bool enabled, int? companyId)
        {
            _receiptService.SetTrackingStatus(enabled);
        }
        public bool Validate(PaymentBundle item)
        {
            return _receiptService.Validate(item);
        }
    }
}
