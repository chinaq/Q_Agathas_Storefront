using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Model.Products;
using Agathas.Storefront.Infrastructure.Domain;

namespace Agathas.Storefront.Model.Categories
{
    public class Category:EntityBase<int>, IAggregateRoot, IProductAttribute
    {
        public string Name { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
