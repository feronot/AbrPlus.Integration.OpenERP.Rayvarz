using AbrPlus.Integration.OpenERP.Api.Contracts;
using AbrPlus.Integration.OpenERP.Api.DataContracts;
using AbrPlus.Integration.OpenERP.Rayvarz.Service;
using AbrPlus.Integration.OpenERP.Settings;
using SeptaKit.DI;

namespace AbrPlus.Integration.OpenERP.Rayvarz.Api.Api.Configuration
{
    public class SettingApi : ISettingApi, IApi
    {
        private readonly ISettingService _settingService;
        public SettingApi(ISettingService settingService)
        {
            _settingService = settingService;
        }


        public int GetCurrentFiscalYear(int companyId)
        {
            return _settingService.GetCurrentFiscalYear(companyId);
        }
        public SystemInfoBundle GetInfo(int companyId)
        {
            return _settingService.GetInfo(companyId);
        }

        public FinancialSystemConfig GetFinancialSystemConfig()
        {
            return _settingService.GetFinancialSystemConfig();
        }
        public void SetFinancialSystemConfig(FinancialSystemConfig config)
        {
            _settingService.SetFinancialSystemConfig(config);
        }
        public void DeleteFinancialSystem()
        {
            _settingService.DeleteFinancialSystem();
        }
        public SettingsTestResult TestFinancialSystemSettings(FinancialSystemSettings settings)
        {
            return _settingService.TestFinancialSystemSettings(settings);
        }

        public CompanyConfig GetCompanyConfig(int companyId)
        {
            return _settingService.GetCompanyConfig(companyId);
        }
        public void SetCompanyConfig(CompanyConfig companyConfig)
        {
            _settingService.SetCompanyConfig(companyConfig);
        }
        public void DeleteCompany(int companyId)
        {
            _settingService.DeleteCompany(companyId);
        }

        public FinancialSystemSpecificConfig[] GetFinancialSystemSpecificConfigs(int companyId)
        {
            return _settingService.GetFinancialSystemSpecificConfigs(companyId);
        }
        public void SetFinancialSystemSpecificConfigs(int companyId, FinancialSystemSpecificConfig[] configs)
        {
            _settingService.SetFinancialSystemSpecificConfigs(companyId, configs);
        }
    }
}
