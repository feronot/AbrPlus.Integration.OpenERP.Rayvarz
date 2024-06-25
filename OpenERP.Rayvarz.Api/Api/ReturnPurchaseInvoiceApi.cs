using AbrPlus.Integration.OpenERP.Api.Contracts;
using AbrPlus.Integration.OpenERP.Api.DataContracts;
using SeptaKit.DI;
using System;

namespace AbrPlus.Integration.OpenERP.Rayvarz.Api.Api
{
    public class ReturnPurchaseInvoiceApi : IReturnPurchaseInvoiceApi, IApi
    {
        public string[] GetAllIds(int? companyId)
        {
            throw new NotImplementedException();
        }

        public InvoiceBundle GetBundle(string key, int? companyId)
        {
            throw new NotImplementedException();
        }

        public ChangeInfo GetChanges(string lastTrackedVersion, int? companyId)
        {
            throw new NotImplementedException();
        }

        public bool Save(InvoiceBundle item, int? companyId)
        {
            throw new NotImplementedException();
        }

        public void SetTrackingStatus(bool enabled, int? companyId)
        {

        }

        public bool Validate(InvoiceBundle item)
        {
            return false;
        }
    }
}
