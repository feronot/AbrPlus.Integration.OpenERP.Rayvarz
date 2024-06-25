using AbrPlus.Integration.OpenERP.Api.Contracts;
using AbrPlus.Integration.OpenERP.Api.DataContracts;
using AbrPlus.Integration.OpenERP.Rayvarz.Service;
using SeptaKit.DI;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbrPlus.Integration.OpenERP.Rayvarz.Api.Api
{
    public class CustomerApi : ICustomerApi, IApi
    {
        private readonly ICustomerService _customerService;
        public CustomerApi(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public List<IdentityBalance> GetAllIdentityBalance(IdentityBalanceParams identityBalanceParams, int companyId)
        {
            return _customerService.GetAllIdentityBalance(identityBalanceParams);
        }
        public string[] GetAllIds(int? companyId)
        {
            return _customerService.GetAllIds();
        }
        public IdentityBundle GetBundle(string key, int? companyId)
        {
            return _customerService.GetBundle(key);
        }
        public IdentityBundle GetBundleByCode(string key, int companyId)
        {
            return _customerService.GetBundleByCode(key);
        }
        public ChangeInfo GetChanges(string lastTrackedVersion, int? companyId)
        {
            return _customerService.GetChanges(lastTrackedVersion);
        }
        public decimal GetCustomerBalance(string customerCode, int companyId)
        {
            return _customerService.GetCustomerBalance(customerCode);
        }
        public bool Save(IdentityBundle item, int? companyId)
        {
            return _customerService.Save(item);
        }
        public void SetTrackingStatus(bool enabled, int? companyId)
        {
            _customerService.SetTrackingStatus(enabled);
        }
        public bool Validate(IdentityBundle item)
        {
            return _customerService.Validate(item);
        }
    }
}
