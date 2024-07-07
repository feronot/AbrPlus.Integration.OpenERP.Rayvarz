using AbrPlus.Integration.OpenERP.Rayvarz.Service.Configuration;
using AbrPlus.Integration.OpenERP.Service;
using AbrPlus.Integration.OpenERP.Service.Configuration;
using Microsoft.Extensions.Options;
using SeptaKit.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AbrPlus.Integration.OpenERP.Rayvarz.Service.Options
{
    public class RayvarzConnectionStringOption : IOptions<ConnectionStringOption>
    {
        private readonly ICompanyContext _companyContext;
        private readonly IRayvarzCompanyOptionStorageService _rayvarzCompanyOptionStorageService;

        public RayvarzConnectionStringOption(ICompanyContext companyContext, IRayvarzCompanyOptionStorageService rayvarzCompanyOptionStorageService)
        {
            _companyContext = companyContext;
            _rayvarzCompanyOptionStorageService = rayvarzCompanyOptionStorageService;
        }
        public ConnectionStringOption Value
        {
            get
            {
                _companyContext.SetCompanyId(100);
                var option = _rayvarzCompanyOptionStorageService.GetCompanyConfig(_companyContext.CompanyId);
                option.ConnecitonString = "";
                var builder = new SqlConnectionStringBuilder(option.ConnecitonString);
                builder.TrustServerCertificate = true;
                return new ConnectionStringOption() { ConnectionString = builder.ConnectionString };
            }
        }
    }
}
