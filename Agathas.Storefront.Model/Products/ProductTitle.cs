using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Model.Categories;
using Agathas.Storefront.Infrastructure.Domain;

namespace Agathas.Storefront.Model.Products
{
    public class ProductTitle:EntityBase<int>, IAggregateRoot
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Brand Brand { get; set; }
        public ProductColor Color { get; set; }
        public Category Category { get; set; }
        public IEnumerable<Product> Products { get; set; }
        
        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
