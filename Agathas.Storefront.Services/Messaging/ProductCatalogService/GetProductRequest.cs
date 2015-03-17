using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agathas.Storefront.Services.Messaging.ProductCatalogService
{
    /// <summary>
    /// 单一商品详细内容的请求
    /// </summary>
    public class GetProductRequest
    {
        public int ProductId { get; set; }
    }
}
