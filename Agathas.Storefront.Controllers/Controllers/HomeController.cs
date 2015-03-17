using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Services.Interfaces;
using System.Web.Mvc;
using Agathas.Storefront.Controllers.ViewModels.ProductCatalog;
using Agathas.Storefront.Services.Messaging.ProductCatalogService;

namespace Agathas.Storefront.Controllers.Controllers
{
    /// <summary>
    /// 主页的controller
    /// </summary>
    public class HomeController : ProductCatalogBaseController
    {
        private readonly IProductCatalogService _productCatalogService;

        public HomeController(IProductCatalogService productCatalogService)
            : base(productCatalogService)
        {
            _productCatalogService = productCatalogService;
        }

        /// <summary>
        /// 主页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            HomePageView homePageView = new HomePageView();
            homePageView.Categories = base.GetCategories();

            GetFeaturedProductsResponse response = _productCatalogService.GetFeatureProducts();
            homePageView.Products = response.Products;

            return View(homePageView);
        }
    }
}
