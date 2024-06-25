using AbrPlus.Integration.OpenERP.Api.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbrPlus.Integration.OpenERP.Rayvarz.Service
{
    public interface IQuoteService
    {
        string[] GetAllIds();
        InvoiceBundle GetBundle(string key);
        ChangeInfo GetChanges(string lastTrackedVersionStamp);
        bool Save(InvoiceBundle item);
        void SetTrackingStatus(bool enabled);
        bool SyncWithCrmObjectTypeCode();
        bool Validate(InvoiceBundle item);
    }
}
