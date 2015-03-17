using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Services.ViewModels;

namespace Agathas.Storefront.Services.Messaging.ProductCatalogService
{
    /// <summary>
    /// 客户具体查询的相应
    /// </summary>
    public class GetProductsByCategoryResponse
    {
        public string SelectedCategoryName { get; set; }
        public int SelectedCategory { get; set; }
        
        public IEnumerable<RefinementGroup> RefinementGroups { get; set; }
        
        public int NumberOfTitlesFound { get; set; }
        public int TotalNumberOfPages { get; set; }
        public int CurrentPage { get; set; }

        public IEnumerable<ProductSummaryView> Products { get; set; }
    }
}
