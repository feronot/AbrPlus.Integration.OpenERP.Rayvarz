using AbrPlus.Integration.OpenERP.Api.DataContracts;

namespace AbrPlus.Integration.OpenERP.Rayvarz.DataContracts
{
    public interface IBaseIntegrationApi<T> where T : BundleBase
    {
        bool Save(T item, int? companyId);
        ChangeInfo GetChanges(string lastTrackedVersion, int? companyId);
        T GetBundle(string key, int? companyId);
        bool Validate(T item);
        void SetTrackingStatus(bool enabled, int? companyId);
        string[] GetAllIds(int? companyId);
    }
}
