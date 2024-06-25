using AbrPlus.Integration.OpenERP.Api.DataContracts;
using System.Collections.Generic;

namespace AbrPlus.Integration.OpenERP.Rayvarz.Service
{
    public interface ICustomerService
    {
        bool Save(IdentityBundle item);
        ChangeInfo GetChanges(string lastTrackedVersion);
        IdentityBundle GetBundle(string key);
        bool Validate(IdentityBundle item);
        void SetTrackingStatus(bool enabled);
        string[] GetAllIds();
        IdentityBundle GetBundleByCode(string key);
        decimal GetCustomerBalance(string customerCode);
        List<IdentityBalance> GetAllIdentityBalance(IdentityBalanceParams identityBalanceParams);
    }
}
