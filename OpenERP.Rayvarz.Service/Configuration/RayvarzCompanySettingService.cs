using Autofac;
using Microsoft.Extensions.Logging;
using SeptaKit.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using AbrPlus.Integration.OpenERP.Rayvarz.Settings;
using AbrPlus.Integration.OpenERP.Settings;
using AbrPlus.Integration.OpenERP.Helpers;
using AbrPlus.Integration.OpenERP.Api.DataContracts;

namespace AbrPlus.Integration.OpenERP.Rayvarz.Service.Configuration
{
    public class RayvarzCompanySettingService : IRayvarzCompanySettingService
    {
        private readonly ILifetimeScope _lifetimeScope;
        private readonly IRayvarzCompanyOptionStorageService _rayvarzCompanyOptionStorageService;
        private readonly ILogger<RayvarzCompanySettingService> _logger;

        public RayvarzCompanySettingService(ILifetimeScope lifetimeScope, IRayvarzCompanyOptionStorageService rayvarzCompanyOptionStorageService, ILogger<RayvarzCompanySettingService> logger)
        {
            _lifetimeScope = lifetimeScope;
            _rayvarzCompanyOptionStorageService = rayvarzCompanyOptionStorageService;
            _logger = logger;
        }

        public List<SettingValue> GetCompanySetting(int companyId, RayvarzSettingKey settingKey)
        {
            using (var scope = _lifetimeScope.BeginLifetimeScopeForCompany(companyId))
            {
                switch (settingKey)
                {
                    case RayvarzSettingKey.DropdownSetting:
                        //ToDo: for check
                        return new List<SettingValue>() { new SettingValue("TestKey1", "TestValue1"), new SettingValue("TestKey2", "TestValue2") };

                    default:
                        throw new Exception($"Invalid Setting Key:{settingKey}");
                }
            }
        }

        public FinancialSystemSpecificConfig[] GetFinancialSystemSpecificConfigs(int companyId)
        {
            try
            {
                var financialConfig = _rayvarzCompanyOptionStorageService.GetConfig();
                var targetCompany = financialConfig.CompanyConfigs.Find(company => company.Id == companyId);

                var configs = _rayvarzCompanyOptionStorageService.GetSpecificConfigs();

                var descriptions = configs.ToDictionary(x => x.Key, y => new Tuple<string, string>(y.Name, y.Description));

                if (targetCompany != null && targetCompany.SpecificSettings.Count > 0)
                {
                    var initializedConfigs = targetCompany.SpecificSettings.ToArray();
                    configs = initializedConfigs.Union(configs, new FinancialSystemSpecificConfigEqualityComaprer()).ToArray();
                }

                for (int i = 0; i < configs.Length; i++)
                {
                    // Make sure name and description changes reflects in UI.
                    if (descriptions.ContainsKey(configs[i].Key))
                    {
                        configs[i].Name = descriptions[configs[i].Key].Item1;
                        configs[i].Description = descriptions[configs[i].Key].Item2;
                    }

                    FillPossibleValues(companyId, configs[i]);
                }

                return configs;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetFinancialSystemSpecificConfigs");
                throw;
            }
        }

        public void SetFinancialSystemSpecificConfigs(int companyId, FinancialSystemSpecificConfig[] configs)
        {
            if (configs == null)
            {
                return;
            }
            try
            {
                _logger.LogInformation("SetFinancialSystemSpecificConfigs");
                var financialSystemConfig = _rayvarzCompanyOptionStorageService.GetConfig();
                _logger.LogInformation("SetFinancialSystemSpecificConfigs 2");
                var targetCompany = financialSystemConfig.CompanyConfigs.Find(company => company.Id == companyId);
                if (targetCompany != null)
                {
                    targetCompany.SpecificSettings.RemoveAll(existingConfig => configs.Any(conf => conf.Key == existingConfig.Key));
                    targetCompany.SpecificSettings.AddRange(configs);
                }
                _logger.LogInformation("SetFinancialSystemSpecificConfigs 3");
                _rayvarzCompanyOptionStorageService.SetConfig(financialSystemConfig);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in SetFinancialSystemSpecificConfigs");
                throw;
            }
        }


        protected void FillPossibleValues(int companyId, FinancialSystemSpecificConfig config)
        {
            if (config.PossibleValues == null)
            {
                config.PossibleValues = new List<FinancialSystemSpecificConfigValue>();
            }

            if (config.PossibleValues.Count > 0)
            {
                return;
            }

            if (Enum.TryParse(config.Key, out RayvarzSettingKey settingKey))
            {
                try
                {
                    var internalSettings = GetCompanySetting(companyId, settingKey).ToArray();
                    var possibleValues = internalSettings.Select(s => new FinancialSystemSpecificConfigValue { Key = s.Name, Value = s.Value });
                    config.PossibleValues.AddRange(possibleValues);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
