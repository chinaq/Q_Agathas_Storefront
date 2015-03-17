using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Model.Categories;
using Agathas.Storefront.Infrastructure.UnitOfWork;

namespace Agathas.Storefront.Repository.NHibernate.Repositories
{
    public class CategoryRepository:Repository<Category, int>, ICategoryRepository
    {
        public CategoryRepository(IUnitOfWork uow)
            : base(uow)
        { 
        }
    }
}
