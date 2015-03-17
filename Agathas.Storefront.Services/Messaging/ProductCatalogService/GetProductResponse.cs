using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Services.ViewModels;

namespace Agathas.Storefront.Services.Messaging.ProductCatalogService
{
    /// <summary>
    /// 单一商品详细内容的响应
    /// </summary>
    public class GetProductResponse
    {
        public ProductView Product { get; set; }
    }
}
