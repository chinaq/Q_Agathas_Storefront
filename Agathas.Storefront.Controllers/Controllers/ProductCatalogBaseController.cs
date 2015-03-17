using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Agathas.Storefront.Services.Interfaces;
using Agathas.Storefront.Services.ViewModels;
using Agathas.Storefront.Services.Messaging.ProductCatalogService;

namespace Agathas.Storefront.Controllers.Controllers
{
    /// <summary>
    /// controller的基类
    /// </summary>
    public class ProductCatalogBaseController:Controller
    {
        private readonly IProductCatalogService _productCatalogService;

        public ProductCatalogBaseController(IProductCatalogService productCatalogService)
        {
            _productCatalogService = productCatalogService;
        }

        /// <summary>
        /// 获取categories
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CategoryView> GetCategories()
        {
            GetAllCategoriesResponse response = _productCatalogService.GetAllCategories();
            return response.Categories;
        }
    }
}
