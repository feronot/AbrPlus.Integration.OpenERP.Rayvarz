using AbrPlus.Integration.OpenERP.Api.DataContracts;
using AbrPlus.Integration.OpenERP.Rayvarz.Repository;
using AbrPlus.Integration.OpenERP.Enums;
using AbrPlus.Integration.OpenERP.Helpers;
using Microsoft.Extensions.Logging;
using SeptaKit.Persian;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace AbrPlus.Integration.OpenERP.Rayvarz.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IRayvarzCompanyService _rayvarzCompanyService;
        private readonly ILogger<CustomerService> _logger;

        public CustomerService(ICustomerRepository customerRepository,
                               IRayvarzCompanyService rayvarzCompanyService,
                               ILogger<CustomerService> logger)
        {
            _customerRepository = customerRepository;
            _rayvarzCompanyService = rayvarzCompanyService;
            _logger = logger;
        }
        public IdentityBundle GetBundle(string key)
        {
            try
            {
                var setting = _rayvarzCompanyService.GetCompanyConfig();

                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetBundle");
                throw;
            }
        }
        public IdentityBundle GetBundleByCode(string key)
        {
            try
            {
                var setting = _rayvarzCompanyService.GetCompanyConfig();

                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetBundleByCode");
                throw;
            }
        }
        public ChangeInfo GetChanges(string lastTrackedVersionStamp)
        {
            var config = _rayvarzCompanyService.GetCompanyConfig();

            long currentTrackingVersion = _customerRepository.GetCurrentTrackingVersion();

            if (long.TryParse(lastTrackedVersionStamp, out var lastTrackedVersion) &&
                currentTrackingVersion == lastTrackedVersion)
            {
                return new ChangeInfo() { LastTrackedVersion = lastTrackedVersionStamp };
            }

            var toReturn = new ChangeInfo() { LastTrackedVersion = currentTrackingVersion.ToString() };

            //ToDo : add changes to toReturn.Changes


            return toReturn;
        }
        public bool Save(IdentityBundle item)
        {
            throw new NotImplementedException();
        }
        public bool Validate(IdentityBundle item)
        {
            throw new NotImplementedException();
        }
        public void SetTrackingStatus(bool enabled)
        {
            if (enabled)
            {
                _customerRepository.EnableTableTracking();
            }
            else
            {
                _customerRepository.DisableTableTracking();
            }
        }
        public string[] GetAllIds()
        {
            var config = _rayvarzCompanyService.GetCompanyConfig();

            throw new NotImplementedException();
        }
        public decimal GetCustomerBalance(string customerCode)
        {
            var config = _rayvarzCompanyService.GetCompanyConfig();
            throw new NotImplementedException();
        }
        public List<IdentityBalance> GetAllIdentityBalance(IdentityBalanceParams identityBalanceParams)
        {
            var config = _rayvarzCompanyService.GetCompanyConfig();
            throw new NotImplementedException();
        }
    }
}
