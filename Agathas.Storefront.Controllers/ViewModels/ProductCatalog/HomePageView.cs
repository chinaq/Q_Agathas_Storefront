using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Services.ViewModels;

namespace Agathas.Storefront.Controllers.ViewModels.ProductCatalog
{
    public class HomePageView : BaseProductCatalogPageView
    {
        public IEnumerable<ProductSummaryView> Products { get; set; }
    }
}
