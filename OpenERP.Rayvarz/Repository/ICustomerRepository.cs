using AbrPlus.Integration.OpenERP.Repository;
using AbrPlus.Integration.OpenERP.Rayvarz.Models;
using SeptaKit.Repository;

namespace AbrPlus.Integration.OpenERP.Rayvarz.Repository
{
    public interface ICustomerRepository : IBaseOpenErpApiRepository<Customer>, ITrackingSupportRepository
    {
    }
}