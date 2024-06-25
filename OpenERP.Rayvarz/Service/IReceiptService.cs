using AbrPlus.Integration.OpenERP.Api.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbrPlus.Integration.OpenERP.Rayvarz.Service
{
    public interface IReceiptService
    {
        string[] GetAllIds();
        PaymentBundle GetBundle(string key);
        ChangeInfo GetChanges(string lastTrackedVersionStamp);
        bool Save(PaymentBundle item);
        void SetTrackingStatus(bool enabled);
        bool Validate(PaymentBundle item);
    }
}
