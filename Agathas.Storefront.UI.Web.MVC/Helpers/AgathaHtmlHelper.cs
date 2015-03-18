using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

namespace Agathas.Storefront.UI.Web.MVC.Helpers
{
    public static class AgathaHtmlHelper
    {
        /// <summary>
        /// 设置跳转页码
        /// </summary>
        /// <param name="html"></param>
        /// <param name="currentPage"></param>
        /// <param name="totalPages"></param>
        /// <param name="pageUrl"></param>
        /// <returns></returns>
        public static string BuildPageLinksFrom(
            this HtmlHelper html, int currentPage, int totalPages, Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 1; i <= totalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                if (i == currentPage)
                    tag.AddCssClass("selected");
                else
                    tag.AddCssClass("notseleted");
            }
            return result.ToString();
        }


        /// <summary>
        /// 获取完全解析资源
        /// </summary>
        /// <param name="html"></param>
        /// <param name="resource"></param>
        /// <returns></returns>
        public static string Resolve(this HtmlHelper html, string resource)
        {
            return Agathas.Storefront.Infrastructure.Helpers.UrlHelper.Resolve(resource);
        }
    }
}