using AbrPlus.Integration.OpenERP.Api.DataContracts;
using Microsoft.Extensions.Logging;
using System;

namespace AbrPlus.Integration.OpenERP.Rayvarz.Service
{
    public class ProductService : IProductService
    {
        private readonly ILogger<ProductService> _logger;

        public ProductService(ILogger<ProductService> logger)
        {
            _logger = logger;
        }
        public ProductBundle GetBundle(string key)
        {
            throw new NotImplementedException();
        }
        public ChangeInfo GetChanges(string lastTrackedVersionStamp)
        {
            throw new NotImplementedException();
        }
        public bool Save(ProductBundle item)
        {
            throw new NotImplementedException();
        }
        public void SetTrackingStatus(bool enabled)
        {

        }
        public bool Validate(ProductBundle item)
        {
            throw new NotImplementedException();
        }
        public string[] GetAllIds()
        {
            throw new NotImplementedException();
        }
    }
}
