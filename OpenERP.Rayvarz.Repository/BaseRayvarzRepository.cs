using AbrPlus.Integration.OpenERP.Hosting.Repository;
using Microsoft.Extensions.Logging;
using SeptaKit.Models;

namespace AbrPlus.Integration.OpenERP.Rayvarz.Repository
{
    public abstract class BaseRayvarzRepository<TEntity, TKey> : BaseOpenErpApiRepository<RayvarzDbContext, TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        protected BaseRayvarzRepository(IRayvarzDbContext dbContext, ILoggerFactory loggerFactory)
            : base(dbContext as RayvarzDbContext, loggerFactory)
        {
        }
    }

    public abstract class BaseRayvarzRepository<TEntity> : BaseOpenErpApiRepository<RayvarzDbContext, TEntity> where TEntity : BaseEntity
    {
        protected BaseRayvarzRepository(IRayvarzDbContext dbContext, ILoggerFactory loggerFactory)
            : base(dbContext as RayvarzDbContext, loggerFactory)
        {
        }
    }
}
