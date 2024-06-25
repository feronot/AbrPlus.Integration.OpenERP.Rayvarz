using AbrPlus.Integration.OpenERP.Helpers;
using AbrPlus.Integration.OpenERP.Options;
using AbrPlus.Integration.OpenERP.Rayvarz.Enums;
using AbrPlus.Integration.OpenERP.Rayvarz.Service.Configuration;
using AbrPlus.Integration.OpenERP.Rayvarz.Settings;
using AbrPlus.Integration.OpenERP.Service;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbrPlus.Integration.OpenERP.Rayvarz.Service
{
    public class RayvarzCompanyService : IRayvarzCompanyService
    {
        private readonly ICompanyContext _companyContext;
        private readonly IRayvarzCompanyOptionService _rayvarzCompanyOptionService;
        private readonly AppOption _appOptions;
        private readonly ILogger<RayvarzCompanyService> _logger;

        public RayvarzCompanyService(ICompanyContext companyContext,
                                      IRayvarzCompanyOptionService rayvarzCompanyOptionService,
                                      IOptions<AppOption> options,
                                      ILogger<RayvarzCompanyService> logger)
        {
            _companyContext = companyContext;
            _rayvarzCompanyOptionService = rayvarzCompanyOptionService;
            _appOptions = options.Value;
            _logger = logger;
        }


        public RayvarzCompanyConfig GetCompanyConfig()
        {
            return _rayvarzCompanyOptionService.GetCompanyFlatConfig(_companyContext.CompanyId);
        }
        public string GetCurrentVersion()
        {
            return "1.0.0";
        }
        public bool IsCurrentVersionCompatible()
        {
            try
            {
                CheckVersionIsCompatible();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public void CheckVersionIsCompatible()
        {
            GetCompatibleVersion();
        }
        public bool TryGetCompatibleVersion(out RayvarzVersion compatibleVersion, out string currentVersion)
        {
            currentVersion = GetCurrentVersion();
            try
            {
                compatibleVersion = GetCompatibleVersion();
                return true;
            }
            catch
            {
                compatibleVersion = RayvarzVersion.None;
                return false;
            }
        }

        private RayvarzVersion GetCompatibleVersion()
        {
            try
            {
                var version = GetCurrentVersion();
                _logger.LogDebug($"Instantiating Rayvarz repository version {version} for company {_companyContext.CompanyId} ...");

                version = "V" + version.Replace('.', '_');
                var releaseVersion = version.Substring(0, version.LastIndexOf('_'));
                var majorVersion = version.Substring(0, version.IndexOf('_'));

                RayvarzVersion rayvarzVersion = RayvarzVersion.None;
                RayvarzVersion rayvarzLastVersion = RayvarzVersion.V2_0_0;

                if (version.IsBiggerVersion(rayvarzLastVersion.ToString()))
                {
                    if (_appOptions.UseLatestVersion)
                    {
                        _logger.LogDebug("Attempting to use latest repository version.");
                        rayvarzVersion = rayvarzLastVersion;
                    }
                    else
                    {
                        throw new Exception(string.Format("ورژن جاری شرکت نمونه {0} میباشد و با ورژن همگام ساز مرتبط نیست. لطفا سرویس همگام ساز را بروز رسانی کنید.", version));
                    }
                }
                else
                {
                    if (!Enum.TryParse(version, true, out rayvarzVersion))
                    {
                        if (!Enum.TryParse(releaseVersion, true, out rayvarzVersion))
                        {
                            if (!Enum.TryParse(majorVersion, true, out rayvarzVersion))
                            {

                            }
                        }
                    }
                }

                if (rayvarzVersion != RayvarzVersion.None)
                {
                    return rayvarzVersion;
                }
                else
                {
                    throw new Exception(string.Format("ورژن جاری شرکت نمونه {0} میباشد و با ورژن همگام ساز مرتبط نیست. لطفا سرویس همگام ساز را بروز رسانی کنید.", version));
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in IsCurrentVersionCompatible");
                throw;
            }
        }


    }
}
