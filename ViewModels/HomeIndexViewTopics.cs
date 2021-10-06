using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebForum.Domain.Models;

namespace WebForum.ViewModels
{
    /// <summary>
    /// Модель представлення Головної сторінки
    /// </summary>
    public class HomeIndexViewTopics
    {
        /// <summary>
        /// Теми на сторінці
        /// </summary>
        public IEnumerable<Topic> TopicsInPage { get; set; }
        /// <summary>
        /// ІНформація про сторінку
        /// </summary>
        public PageInfo PageInfo { get; set; }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="topics">Теми</param>
        /// <param name="pageInfo">Інформація про сторінку</param>
        public HomeIndexViewTopics(IEnumerable<Topic> topics, PageInfo pageInfo)
        {
            TopicsInPage = topics;
            PageInfo = pageInfo;
        }
    }
}