using AbrPlus.Integration.OpenERP.Api.Contracts;
using AbrPlus.Integration.OpenERP.Api.DataContracts;
using AbrPlus.Integration.OpenERP.Rayvarz.Service;
using SeptaKit.DI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbrPlus.Integration.OpenERP.Rayvarz.Api.Api
{
    public class ProductApi : IProductApi, IApi
    {
        private readonly IProductService _productService;
        public ProductApi(IProductService productService)
        {
            _productService = productService;
        }

        public string[] GetAllIds(int? companyId)
        {
            return _productService.GetAllIds();
        }
        public ProductBundle GetBundle(string key, int? companyId)
        {
            return _productService.GetBundle(key);
        }
        public ChangeInfo GetChanges(string lastTrackedVersion, int? companyId)
        {
            return _productService.GetChanges(lastTrackedVersion);
        }
        public bool Save(ProductBundle item, int? companyId)
        {
            return _productService.Save(item);
        }
        public void SetTrackingStatus(bool enabled, int? companyId)
        {
            _productService.SetTrackingStatus(enabled);
        }
        public bool Validate(ProductBundle item)
        {
            return _productService.Validate(item);
        }
    }
}
