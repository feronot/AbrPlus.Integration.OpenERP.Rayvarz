using AbrPlus.Integration.OpenERP.Rayvarz.Models;
using Microsoft.Extensions.Logging;
using SeptaKit.Repository.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbrPlus.Integration.OpenERP.Rayvarz.Repository
{
    public class CustomerRepository : BaseRayvarzRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IRayvarzDbContext dbContext, ILoggerFactory loggerFactory) : base(dbContext, loggerFactory)
        {
        }
    }
}
