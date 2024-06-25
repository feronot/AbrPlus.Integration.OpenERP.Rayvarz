using AbrPlus.Integration.OpenERP.Rayvarz.Repository;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SeptaKit.Repository;

namespace AbrPlus.Integration.OpenERP.Rayvarz.Repository
{
    public partial class RayvarzDbContext : IRayvarzDbContext
    {
        protected override string MigrationTableSchema => "dbo";
        protected override string MigrationTableName => "__RayvarzMigrationHistory";


        public RayvarzDbContext(IOptions<ConnectionStringOption> options, ILoggerFactory loggerFactory)
            :base(options, loggerFactory)
        {

        }        
    }
}
