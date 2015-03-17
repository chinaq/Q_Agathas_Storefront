using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Agathas.Storefront.Model.Products;
using Agathas.Storefront.Services.ViewModels;
using Agathas.Storefront.Model.Categories;
using Agathas.Storefront.Infrastructure.Helpers;

namespace Agathas.Storefront.Services
{
    public class AutoMapperBootStrapper
    {
        public static void ConfigureAutoMapper()
        {
            //ProcutTitle类、Product类
            Mapper.CreateMap<ProductTitle, ProductSummaryView>();
            Mapper.CreateMap<ProductTitle, ProductView>();
            Mapper.CreateMap<Product, ProductSummaryView>();
            Mapper.CreateMap<Product, ProductSizeOption>();

            //Category类
            Mapper.CreateMap<Category, CategoryView>();

            //IProductAttribute
            Mapper.CreateMap<IProductAttribute, Refinement>();

            //货币格式化
            Mapper.AddFormatter<MoneyFormatter>();
        }


        /// <summary>
        /// 格式化价格
        /// </summary>
        public class MoneyFormatter : IValueFormatter
        {
            public string FormatValue(ResolutionContext context)
            {
                if (context.SourceValue is decimal)
                {
                    decimal money = (decimal)context.SourceValue;
                    return money.FormatMoney();
                }
                return context.SourceValue.ToString();
            }
        }
    }
}
