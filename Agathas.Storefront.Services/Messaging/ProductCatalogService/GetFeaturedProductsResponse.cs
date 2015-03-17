using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Services.ViewModels;

namespace Agathas.Storefront.Services.Messaging.ProductCatalogService
{
    /// <summary>
    /// 获取精选商品
    /// </summary>
    public class GetFeaturedProductsResponse
    {
        public IEnumerable<ProductSummaryView> Products { get; set; }
    }
}
