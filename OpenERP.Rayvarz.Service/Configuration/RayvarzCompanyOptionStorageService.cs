using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Options;
using AbrPlus.Integration.OpenERP.Settings;
using Microsoft.Extensions.Logging;
using SeptaKit.Extensions;
using AbrPlus.Integration.OpenERP.Rayvarz.Settings;
using AbrPlus.Integration.OpenERP.Service.Configuration;
using AbrPlus.Integration.OpenERP.Options;

namespace AbrPlus.Integration.OpenERP.Rayvarz.Service.Configuration
{
    public class RayvarzCompanyOptionStorageService : ConfigurationStorageServiceBase<RayvarzSetting>, IRayvarzCompanyOptionStorageService
    {
        private readonly string _storagePath;
        private readonly IOptions<AppOption> _options;

        protected override string StoragePath
        {
            get
            {
                if (string.IsNullOrEmpty(_storagePath))
                {
                    var rawPath = _options.Value.StoragePath;
                    if (string.IsNullOrEmpty(rawPath))
                    {
                        throw new InvalidOperationException("StoragePath key is not set in app.settings");
                    }

                    return Environment.ExpandEnvironmentVariables(rawPath);
                }
                else
                {
                    return Environment.ExpandEnvironmentVariables(_storagePath);
                }
            }
        }

        public RayvarzCompanyOptionStorageService(IOptions<AppOption> options, ILoggerFactory loggerFactory)
            : base(loggerFactory)
        {
            _options = options;
        }
    }
}
