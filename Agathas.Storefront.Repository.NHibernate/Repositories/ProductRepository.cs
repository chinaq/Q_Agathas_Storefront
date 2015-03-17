using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Model.Products;
using Agathas.Storefront.Infrastructure.UnitOfWork;
using NHibernate;

namespace Agathas.Storefront.Repository.NHibernate.Repositories
{
    public class ProductRepository : Repository<Product, int>, IProductRepository
    {
        public ProductRepository(IUnitOfWork uow)
            : base(uow)
        {

        }

        public override void AppendCriteria(ICriteria criteria)
        {
            criteria.CreateAlias("Title", "ProductTitle");  //建立两表关系（属性，相关表名）
            criteria.CreateAlias("ProductTitle.Category", "Category");
            criteria.CreateAlias("ProductTitle.Brand", "Brand");
            criteria.CreateAlias("ProductTitle.Color", "Color");
        }

    }

}
