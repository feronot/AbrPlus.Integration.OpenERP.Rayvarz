using AbrPlus.Integration.OpenERP.Api.DataContracts;

namespace AbrPlus.Integration.OpenERP.Rayvarz.Service
{
    public interface IContractService
    {
        string[] GetAllIds();
        ContractBundle GetBundle(string key);
        ChangeInfo GetChanges(string lastTrackedVersionStamp);
        bool Save(ContractBundle item);
        void SetTrackingStatus(bool enabled);
        bool SyncWithCrmObjectTypeCode();
        bool Validate(ContractBundle item);
    }
}
