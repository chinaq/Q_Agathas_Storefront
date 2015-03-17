using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Services.Interfaces;
using System.Web.Mvc;
using Agathas.Storefront.Services.Messaging.ProductCatalogService;
using Agathas.Storefront.Controllers.ViewModels.ProductCatalog;
using Agathas.Storefront.Infrastructure.Configuration;
using Agathas.Storefront.Services.ViewModels;
using Agathas.Storefront.Controllers.JsonDTOs;

namespace Agathas.Storefront.Controllers.Controllers
{
    /// <summary>
    /// product的controller
    /// </summary>
    public class ProductController : ProductCatalogBaseController
    {
        private readonly IProductCatalogService _productService;

        public ProductController(IProductCatalogService productService)
            : base(productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// 按Category获取products
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public ActionResult GetProductsByCategory(int categoryId)
        {
            GetProductsByCategoryRequest productSearchRequest = GenerateInitialProductSearchRequestFrom(categoryId);
            GetProductsByCategoryResponse response = _productService.GetProductsByCategory(productSearchRequest);
            ProductSearchResultView productSearchResultView = GetProductSearchResultViewFrom(response);
            return View("ProductSearchResults", productSearchResultView);
        }


        private ProductSearchResultView GetProductSearchResultViewFrom(GetProductsByCategoryResponse response)
        {
            ProductSearchResultView productSearchResultView = new ProductSearchResultView();
            productSearchResultView.Categories = base.GetCategories();
            productSearchResultView.CurrentPage = response.CurrentPage;
            productSearchResultView.NumberOfTitlesFound = response.NumberOfTitlesFound;
            productSearchResultView.Products = response.Products;

            productSearchResultView.RefinementGroups = response.RefinementGroups;
            productSearchResultView.SelectCategory = response.SelectedCategory;
            productSearchResultView.SelectCategoryName = response.SelectedCategoryName;
            productSearchResultView.TotalNumberPages = response.TotalNumberOfPages;
            return productSearchResultView;
        }


        private static GetProductsByCategoryRequest GenerateInitialProductSearchRequestFrom(int categoryId)
        {
            GetProductsByCategoryRequest productSearchRequest = new GetProductsByCategoryRequest();
            productSearchRequest.NumberOfResultsPerPage = int.Parse(
                ApplicationSettingsFactory.GetApplicationSettings().NumberOfResultsPerpage);
            productSearchRequest.CategoryId = categoryId;
            productSearchRequest.Index = 1;
            productSearchRequest.SortBy = ProductsSortBy.PriceHighToLow;
            return productSearchRequest;
        }


        /// <summary>
        /// 通过Ajax获取到products
        /// </summary>
        /// <param name="jsonProductSearchRequest"></param>
        /// <returns></returns>
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult GetProductsByAjax(JsonProductSearchRequest jsonProductSearchRequest)
        {
            GetProductsByCategoryRequest productSearchRequest = GetProductSearchResultViewFrom(jsonProductSearchRequest);
            GetProductsByCategoryResponse response = _productService.GetProductsByCategory(productSearchRequest);
            ProductSearchResultView productSearchResultView = GetProductSearchResultViewFrom(response);
            return Json(productSearchResultView);
        }

        private GetProductsByCategoryRequest GetProductSearchResultViewFrom(JsonProductSearchRequest jsonProductSearchRequest)
        {
            GetProductsByCategoryRequest productSearchRequest = new GetProductsByCategoryRequest();
            productSearchRequest.NumberOfResultsPerPage = int.Parse(
                ApplicationSettingsFactory.GetApplicationSettings().NumberOfResultsPerpage);
            productSearchRequest.Index = jsonProductSearchRequest.Index;
            productSearchRequest.CategoryId = jsonProductSearchRequest.CategoryId;
            productSearchRequest.SortBy = jsonProductSearchRequest.SortBy;

            List<RefinementGroup> refinementGroups = new List<RefinementGroup>();
            RefinementGroup refinementGroup;

            foreach (JsonRefinementGroup jsonRefinementGroup in jsonProductSearchRequest.RefinementGroups)
            {
                switch ((RefinementGroupings)jsonRefinementGroup.GroupId)
                {
                    case RefinementGroupings.brand:
                        productSearchRequest.BrandIds = jsonRefinementGroup.SelectedRefinements;
                        break;
                    case RefinementGroupings.color:
                        productSearchRequest.ColorIds = jsonRefinementGroup.SelectedRefinements;
                        break;
                    case RefinementGroupings.size:
                        productSearchRequest.SizeIds = jsonRefinementGroup.SelectedRefinements;
                        break;
                    default:
                        break;
                }
            }
            return productSearchRequest;
        }


        /// <summary>
        /// 获取到products详细信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Detail(int id)
        {
            ProductDetailView productDetailView = new ProductDetailView();
            GetProductRequest request = new GetProductRequest() { ProductId = id };
            GetProductResponse response = _productService.GetProduct(request);

            ProductView productView = response.Product;
            productDetailView.Product = productView;
            productDetailView.Categories = base.GetCategories();

            return View(productDetailView);
        }
    }

}