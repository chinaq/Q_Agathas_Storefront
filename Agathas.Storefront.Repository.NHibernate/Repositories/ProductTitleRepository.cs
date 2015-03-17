using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Model.Products;
using Agathas.Storefront.Infrastructure.UnitOfWork;

namespace Agathas.Storefront.Repository.NHibernate.Repositories
{
    public class ProductTitleRepository:Repository<ProductTitle, int>, IProductTitleRepository
    {
        public ProductTitleRepository(IUnitOfWork uow)
            : base(uow)
        { 
        }
    }
}
