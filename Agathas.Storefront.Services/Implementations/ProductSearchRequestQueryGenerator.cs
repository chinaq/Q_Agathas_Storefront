using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Infrastructure.Querying;
using Agathas.Storefront.Services.Messaging.ProductCatalogService;
using Agathas.Storefront.Model.Products;

namespace Agathas.Storefront.Services.Implementations
{
    public static class ProductSearchRequestQueryGenerator
    {
        /// <summary>
        /// 将CategoryRequest转换成query
        /// </summary>
        /// <param name="getProductsByCategoryRequest"></param>
        /// <returns></returns>
        public static Query CreateQueryFor(GetProductsByCategoryRequest getProductsByCategoryRequest)
        {
            Query productQuery = new Query();
            Query colorQuery = new Query();
            Query brandQuery = new Query();
            Query sizeQuery = new Query();

            //生成颜色color查询query
            colorQuery.QueryOperator = QueryOperator.Or;
            foreach (int id in getProductsByCategoryRequest.ColorIds)
                colorQuery.Add(Criterion.Create<Product>(p => p.Color.Id, id, CriteriaOperator.Equal));
            if (colorQuery.Criteria.Count()>0)
                productQuery.AddSubQuery(colorQuery);

            //生成品牌brand查询query
            brandQuery.QueryOperator = QueryOperator.Or;
            foreach (int id in getProductsByCategoryRequest.BrandIds)
                brandQuery.Add(Criterion.Create<Product>(p => p.Brand.Id, id, CriteriaOperator.Equal));
            if (brandQuery.Criteria.Count() > 0)
                productQuery.AddSubQuery(brandQuery);

            //生成尺寸size查询query
            sizeQuery.QueryOperator = QueryOperator.Or;
            foreach (int id in getProductsByCategoryRequest.SizeIds)
                sizeQuery.Add(Criterion.Create<Product>(p => p.Size.Id, id, CriteriaOperator.Equal));
            if (sizeQuery.Criteria.Count() > 0)
                productQuery.AddSubQuery(sizeQuery);

            //生成类别Category查询query
            productQuery.Add(Criterion.Create<Product>(
                p => p.Category.Id, getProductsByCategoryRequest.CategoryId, CriteriaOperator.Equal));

            return productQuery;
        }
    }
}
