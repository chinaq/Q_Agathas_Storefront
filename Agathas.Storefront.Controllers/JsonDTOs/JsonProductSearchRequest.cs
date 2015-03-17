using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Web.Mvc;
using Agathas.Storefront.Controllers.JsonDTOs;
using Agathas.Storefront.Services.Messaging.ProductCatalogService;

namespace Agathas.Storefront.Controllers.JsonDTOs
{
    /// <summary>
    /// json化的request
    /// </summary>
    [DataContract]
    [ModelBinder(typeof(JsonModelBinder))]
    public class JsonProductSearchRequest
    {
        [DataMember]
        public int CategoryId { get; set; }
        
        [DataMember]
        public int[] ColorIds { get; set; }
        
        [DataMember]
        public int[] SizeIds { get; set; }
        
        [DataMember]
        public int[] BrandIds { get; set; }
        
        [DataMember]
        public ProductsSortBy SortBy { get; set; }
        
        [DataMember]
        public IEnumerable<JsonRefinementGroup> RefinementGroups { get; set; }
        
        [DataMember]
        public int Index { get; set; }
    }
}
