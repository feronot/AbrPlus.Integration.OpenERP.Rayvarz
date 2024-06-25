using AbrPlus.Integration.OpenERP.Api.DataContracts;

namespace AbrPlus.Integration.OpenERP.Rayvarz.Service
{
    public interface IProductService
    {
        string[] GetAllIds();
        ProductBundle GetBundle(string key);
        ChangeInfo GetChanges(string lastTrackedVersionStamp);
        bool Save(ProductBundle item);
        void SetTrackingStatus(bool enabled);
        bool Validate(ProductBundle item);
    }
}
