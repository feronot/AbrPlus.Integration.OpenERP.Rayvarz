using AbrPlus.Integration.OpenERP.Api.Contracts;
using AbrPlus.Integration.OpenERP.Api.DataContracts;
using SeptaKit.DI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbrPlus.Integration.OpenERP.Rayvarz.Api.Api
{
    public class PurchaseQuoteApi : IPurchaseQuoteApi, IApi
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
