using AbrPlus.Integration.OpenERP.Rayvarz.Enums;
using AbrPlus.Integration.OpenERP.Rayvarz.Settings;
using AbrPlus.Integration.OpenERP.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbrPlus.Integration.OpenERP.Rayvarz.Service
{
    public interface IRayvarzCompanyService : ICompanyService<RayvarzVersion, RayvarzCompanyConfig>
    {
    }
}
