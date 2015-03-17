using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Services.ViewModels;

namespace Agathas.Storefront.Controllers.ViewModels.ProductCatalog
{
    public class ProductSearchResultView : BaseProductCatalogPageView
    {
        public ProductSearchResultView()
        {
            RefinementGroups = new List<RefinementGroup>();
        }

        public string SelectCategoryName { get; set; }
        public int SelectCategory { get; set; }
        public IEnumerable<RefinementGroup> RefinementGroups { get; set; }
       
        public int NumberOfTitlesFound { get; set; }
        public int TotalNumberPages { get; set; }
        public int CurrentPage { get; set; }
        public IEnumerable<ProductSummaryView> Products { get; set; }
    }
}