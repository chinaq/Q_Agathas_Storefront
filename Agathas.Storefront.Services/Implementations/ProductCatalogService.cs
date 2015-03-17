using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Services.Interfaces;
using Agathas.Storefront.Model.Products;
using Agathas.Storefront.Model.Categories;
using Agathas.Storefront.Services.Messaging.ProductCatalogService;
using Agathas.Storefront.Infrastructure.Querying;
using Agathas.Storefront.Services.Mapping;

namespace Agathas.Storefront.Services.Implementations
{
    public class ProductCatalogService : IProductCatalogService
    {
        private readonly IProductTitleRepository _productTitleRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductCatalogService(
            IProductTitleRepository productTitleRepository,
            IProductRepository productRepository,
            ICategoryRepository categoryRepository)
        {
            _productTitleRepository = productTitleRepository;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }



        private IEnumerable<Product> GetAllProductsMatchingQueryAndSort(
            GetProductsByCategoryRequest request, Query productQuery)
        {
            IEnumerable<Product> productsMatchingRefinement = _productRepository.FindBy(productQuery);
            switch (request.SortBy)
            {

                case ProductsSortBy.PriceLowToHigh:
                    productsMatchingRefinement = productsMatchingRefinement.OrderBy(p => p.Price);
                    break;
                case ProductsSortBy.PriceHighToLow:
                    productsMatchingRefinement = productsMatchingRefinement.OrderByDescending(p => p.Price);
                    break;
            }
            return productsMatchingRefinement;
        }


        /// <summary>
        /// 获取按价格排序的前6种商品
        /// </summary>
        /// <returns></returns>
        public GetFeaturedProductsResponse GetFeatureProducts()
        {
            GetFeaturedProductsResponse response = new GetFeaturedProductsResponse();
            Query productQuery = new Query();
            productQuery.OrderByProperty = new OrderByClause()
            {
                Desc = true,
                PropertyName = PropertyNameHelper.ResolvePropertyName<ProductTitle>(pt => pt.Price)
            };
            response.Products = _productTitleRepository.FindBy(productQuery, 0, 6).ConvertToProductViews();
            return response;
        }

        /// <summary>
        /// 获取按顾客需求搜索到的商品
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public GetProductsByCategoryResponse GetProductsByCategory(GetProductsByCategoryRequest request)
        {
            GetProductsByCategoryResponse response;
            Query productQuery = ProductSearchRequestQueryGenerator.CreateQueryFor(request);
            IEnumerable<Product> productsMatchingRefinement = GetAllProductsMatchingQueryAndSort(request, productQuery);
            response = productsMatchingRefinement.CreateProductSearcResultFrom(request);
            response.SelectedCategoryName = _categoryRepository.FindBy(request.CategoryId).Name;
            return response;
        }

        /// <summary>
        /// 获取单一商品
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public GetProductResponse GetProduct(GetProductRequest request)
        {
            GetProductResponse response = new GetProductResponse();
            ProductTitle productTitle = _productTitleRepository.FindBy(request.ProductId);
            response.Product = productTitle.ConvertToProductDetailView();
            return response;
        }

        /// <summary>
        /// 获取商品分类列表
        /// </summary>
        /// <returns></returns>
        public GetAllCategoriesResponse GetAllCategories()
        {
            GetAllCategoriesResponse response = new GetAllCategoriesResponse();
            IEnumerable<Category> categories = _categoryRepository.FindAll();
            response.Categories = categories.ConvertToCategoryViews();
            return response;
        }
    }
}
