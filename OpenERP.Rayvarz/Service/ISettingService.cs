using AbrPlus.Integration.OpenERP.Api.DataContracts;
using AbrPlus.Integration.OpenERP.Settings;

namespace AbrPlus.Integration.OpenERP.Rayvarz.Service
{
    public interface ISettingService
    {
        void DeleteCompany(int companyId);
        void DeleteFinancialSystem();
        CompanyConfig GetCompanyConfig(int companyId);
        int GetCurrentFiscalYear(int companyId);
        FinancialSystemConfig GetFinancialSystemConfig();
        FinancialSystemSpecificConfig[] GetFinancialSystemSpecificConfigs(int companyId);
        SystemInfoBundle GetInfo(int companyId);
        void SetCompanyConfig(CompanyConfig companyConfig);
        void SetFinancialSystemConfig(FinancialSystemConfig config);
        void SetFinancialSystemSpecificConfigs(int companyId, FinancialSystemSpecificConfig[] configs);
        SettingsTestResult TestFinancialSystemSettings(FinancialSystemSettings settings);
    }
}
