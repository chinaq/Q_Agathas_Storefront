using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Services.ViewModels;

namespace Agathas.Storefront.Controllers.ViewModels.ProductCatalog
{
    public abstract class BaseProductCatalogPageView
    {
        public IEnumerable<CategoryView> Categories { get; set; }
    }
}
