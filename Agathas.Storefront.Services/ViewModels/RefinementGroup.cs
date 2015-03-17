using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agathas.Storefront.Services.ViewModels
{
    /// <summary>
    /// 特定分类组
    /// </summary>
    public class RefinementGroup
    {
        public string Name { get; set; }
        public int GroupId { get; set; }
        public IEnumerable<Refinement> Refinements { get; set; }
    }
}
