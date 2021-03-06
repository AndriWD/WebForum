using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebForum.ViewModels;

namespace WebForum.Infrastructure.Business
{
    /// <summary>
    /// Методи розширення
    /// </summary>
    public static class ExtensionsMethods
    {
        /// <summary>
        /// Створення посилань на сторінки
        /// </summary>
        /// <param name="html">Html хелпер</param>
        /// <param name="pageInfo">Інформація про сторінку</param>
        /// <param name="pageUrl">Посилання</param>
        /// <returns></returns>
        public static MvcHtmlString PageLinks(this HtmlHelper html, PageInfo pageInfo, Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            for(int i = 1; i <= pageInfo.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();

                if (i == pageInfo.PageNumber)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("btn btn-default");
                result.Append(tag.ToString());
            }
            return MvcHtmlString.Create(result.ToString());
        }        
    }
}