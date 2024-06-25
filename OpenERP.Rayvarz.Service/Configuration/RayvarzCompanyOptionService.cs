using AbrPlus.Integration.OpenERP.Rayvarz.Settings;
using AbrPlus.Integration.OpenERP.Service.Configuration;
using AbrPlus.Integration.OpenERP.Settings;
using System;

namespace AbrPlus.Integration.OpenERP.Rayvarz.Service.Configuration
{
    public class RayvarzCompanyOptionService : IRayvarzCompanyOptionService
    {
        private readonly IRayvarzCompanyOptionStorageService _rayvarzCompanyOptionStorageService;

        public RayvarzCompanyOptionService(IRayvarzCompanyOptionStorageService rayvarzCompanyOptionStorageService)
        {
            _rayvarzCompanyOptionStorageService = rayvarzCompanyOptionStorageService;
        }

        public RayvarzCompanyConfig GetCompanyFlatConfig(int companyId)
        {
            var company = _rayvarzCompanyOptionStorageService.GetCompanyConfig(companyId) ?? new CompanyConfig()/* empty company. */;
            var settings = _rayvarzCompanyOptionStorageService.GetFinancialSpecificModel(companyId);

            return new RayvarzCompanyConfig
            {
                ConnectionString = company.ConnecitonString,

                CheckBoxSetting = settings.CheckBoxSetting,
                DropdownSetting = settings.DropdownSetting,
                StringSetting = settings.StringSetting,
            };
        }
    }
}
