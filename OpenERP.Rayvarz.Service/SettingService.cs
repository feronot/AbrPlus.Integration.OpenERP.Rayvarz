using Autofac;
using Microsoft.Extensions.Logging;
using System;
using AbrPlus.Integration.OpenERP.Rayvarz.Service.Configuration;
using AbrPlus.Integration.OpenERP.Rayvarz.Enums;
using AbrPlus.Integration.OpenERP.Api.DataContracts;
using AbrPlus.Integration.OpenERP.Settings;
using AbrPlus.Integration.OpenERP.Helpers;
using AbrPlus.Integration.OpenERP.Service.Configuration;

namespace AbrPlus.Integration.OpenERP.Rayvarz.Service
{
    public class SettingService : ISettingService
    {
        private readonly ILifetimeScope _lifetimeScope;
        private readonly IRayvarzCompanySettingService _rayvarzCompanySettingService;
        private readonly IRayvarzCompanyOptionStorageService _rayvarzCompanyOptionStorageService;
        private readonly IConnectionStringValidator _connectionStringValidator;
        private readonly ILogger<SettingService> _logger;
        public SettingService(ILifetimeScope lifetimeScope,
                               IRayvarzCompanySettingService rayvarzCompanySettingService,
                               IRayvarzCompanyOptionStorageService rayvarzCompanyOptionStorageService,
                               IConnectionStringValidator connectionStringValidator,
                               ILogger<SettingService> logger)
        {
            _lifetimeScope = lifetimeScope;
            _rayvarzCompanySettingService = rayvarzCompanySettingService;
            _rayvarzCompanyOptionStorageService = rayvarzCompanyOptionStorageService;
            _connectionStringValidator = connectionStringValidator;
            _logger = logger;
        }
        public SystemInfoBundle GetInfo(int companyId)
        {
            using (var scope = _lifetimeScope.BeginLifetimeScopeForCompany(companyId))
            {
                var companyService = scope.Resolve<IRayvarzCompanyService>();
                var systemInfo = new SystemInfoBundle
                {
                    Name = "شرکت مهندسی نرم افزار رایورز",

                };
                if (companyService.TryGetCompatibleVersion(out RayvarzVersion rayvarzVersion, out string currentVersion))
                {
                    systemInfo.Version = currentVersion;
                    systemInfo.VersionIsSupported = true;
                }
                else
                {
                    systemInfo.Version = currentVersion;
                    systemInfo.VersionIsSupported = false;
                }
                return systemInfo;
            }
        }

        public SettingsTestResult TestFinancialSystemSettings(FinancialSystemSettings settings)
        {
            try
            {
                var message = string.Empty;
                var result = _connectionStringValidator.Validate(settings.DatabaseAddress, settings.UseWindowsCredential, settings.DatabaseUsername, settings.DatabasePassword, out message);

                return new SettingsTestResult
                {
                    Success = result,
                    ErrorMessage = message
                };
            }
            catch (Exception ex)
            {
                return new SettingsTestResult
                {
                    ErrorMessage = ex.Message,
                    Success = false
                };
            }
        }
        public void DeleteFinancialSystem()
        {
            _rayvarzCompanyOptionStorageService.RemoveFinancialSystem();
        }
        public FinancialSystemConfig GetFinancialSystemConfig()
        {
            return _rayvarzCompanyOptionStorageService.GetConfig();
        }
        public void SetFinancialSystemConfig(FinancialSystemConfig config)
        {
            _rayvarzCompanyOptionStorageService.SetConfig(config);
        }
        public CompanyConfig GetCompanyConfig(int companyId)
        {
            return _rayvarzCompanyOptionStorageService.GetCompanyConfig(companyId);
        }
        public void SetCompanyConfig(CompanyConfig companyConfig)
        {
            _rayvarzCompanyOptionStorageService.SetCompanyConfig(companyConfig);
        }
        public void DeleteCompany(int companyId)
        {
            _rayvarzCompanyOptionStorageService.DeleteCompany(companyId);
        }
        public FinancialSystemSpecificConfig[] GetFinancialSystemSpecificConfigs(int companyId)
        {
            return _rayvarzCompanySettingService.GetFinancialSystemSpecificConfigs(companyId);
        }
        public void SetFinancialSystemSpecificConfigs(int companyId, FinancialSystemSpecificConfig[] configs)
        {
            if (configs == null || configs.Length == 0)
                return;

            _rayvarzCompanySettingService.SetFinancialSystemSpecificConfigs(companyId, configs);
        }
        public int GetCurrentFiscalYear(int companyId)
        {
            using (var scope = _lifetimeScope.BeginLifetimeScopeForCompany(companyId))
            {
                throw new NotImplementedException();
            }
        }
    }
}
