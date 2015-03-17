using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Services.Messaging.ProductCatalogService;
using Agathas.Storefront.Model.Products;
using Agathas.Storefront.Services.ViewModels;

namespace Agathas.Storefront.Services.Mapping
{
    public static class ProductMapper
    {
        /// <summary>
        /// 将领域商品集合IEn_Product转换成视图商品集合GetProductsByCategoryResponse
        /// </summary>
        /// <param name="productsMatchingRefinement"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public static GetProductsByCategoryResponse CreateProductSearcResultFrom(
            this IEnumerable<Product> productsMatchingRefinement, GetProductsByCategoryRequest request)
        {
            GetProductsByCategoryResponse productSearchResultView = new GetProductsByCategoryResponse();
            IEnumerable<ProductTitle> productsFound = productsMatchingRefinement.Select(p => p.Title).Distinct();

            productSearchResultView.SelectedCategory = request.CategoryId;
            productSearchResultView.NumberOfTitlesFound = productsFound.Count();
            productSearchResultView.TotalNumberOfPages =
                NoOfResultPagesGiven(request.NumberOfResultsPerPage, productSearchResultView.NumberOfTitlesFound);
            productSearchResultView.RefinementGroups = GenerateAvailableProductRefinementsFrom(productsFound);
            productSearchResultView.Products =
                CropProductListToSatisfyGivenIndex(request.Index, request.NumberOfResultsPerPage, productsFound);

            return productSearchResultView;
        }


        /// <summary>
        /// 获取到第几页的
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="numberOfResultsPerPage"></param>
        /// <param name="productsFound"></param>
        /// <returns></returns>
        private static IEnumerable<ProductSummaryView> CropProductListToSatisfyGivenIndex(
            int pageIndex, int numberOfResultsPerPage, IEnumerable<ProductTitle> productsFound)
        {
            if (pageIndex > 1)
            {
                int numToSkip = (pageIndex - 1) * numberOfResultsPerPage;
                return productsFound
                    .Skip(numToSkip)
                    .Take(numberOfResultsPerPage)
                    .ConvertToProductViews();
            }
            else
            {
                return productsFound
                    .Take(numberOfResultsPerPage)
                    .ConvertToProductViews();
            }
        }

        /// <summary>
        /// 一共要分几页
        /// </summary>
        /// <param name="numberOfResultsPerPage"></param>
        /// <param name="numberOfTitlesFound"></param>
        /// <returns></returns>
        private static int NoOfResultPagesGiven(int numberOfResultsPerPage, int numberOfTitlesFound)
        {
            if (numberOfTitlesFound < numberOfResultsPerPage)
            {
                return 1;
            }
            else
            {
                return (numberOfTitlesFound / numberOfResultsPerPage) 
                    + (numberOfTitlesFound % numberOfResultsPerPage);
            }

        }

        /// <summary>
        /// 获取产品所有的规格（品牌、颜色）和规格值（nike，addidas）
        /// </summary>
        /// <param name="productsFound"></param>
        /// <returns></returns>
        private static IList<ViewModels.RefinementGroup> GenerateAvailableProductRefinementsFrom(
            IEnumerable<ProductTitle> productsFound)
        {
            var brandsRefinementGroup = productsFound
                .Select(p => p.Brand).Distinct().ToList()
                .ConvertAll<IProductAttribute>(b => (IProductAttribute)b)
                .ConvertToRefinementGroup(RefinementGroupings.brand);

            var colorsRefinementGroup = productsFound
                .Select(p => p.Color).Distinct().ToList()
                .ConvertAll<IProductAttribute>(c => (IProductAttribute)c)
                .ConvertToRefinementGroup(RefinementGroupings.color);

            var sizesRefinementGroup = (from p in productsFound
                                        from si in p.Products
                                        select si.Size).Distinct().ToList()
                .ConvertAll<IProductAttribute>(s => (IProductAttribute)s)
                .ConvertToRefinementGroup(RefinementGroupings.size);

            IList<RefinementGroup> refinementGroups = new List<RefinementGroup>();
            refinementGroups.Add(brandsRefinementGroup);
            refinementGroups.Add(colorsRefinementGroup);
            refinementGroups.Add(sizesRefinementGroup);

            return refinementGroups;
        }

    }

}
