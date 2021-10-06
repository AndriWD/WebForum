using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebForum.Domain.Models;

namespace WebForum.ViewModels
{
    /// <summary>
    /// Модель представлення Теми з дописами
    /// </summary>
    public class TopicsDetailsViewTopicPosts
    {
        /// <summary>
        /// Тема
        /// </summary>
        public Topic Topic { get; set; }
        /// <summary>
        /// Дописи на сторінці
        /// </summary>
        public IEnumerable<Post> PostsPerPage { get; set; }
        /// <summary>
        /// ІНформація про сторінку
        /// </summary>
        public PageInfo PageInfo { get; set; }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="topic">Тема</param>
        /// <param name="posts">Дописи</param>
        /// <param name="pageInfo">Інформація про сторінку</param>
        public TopicsDetailsViewTopicPosts(Topic topic, IEnumerable<Post> posts, PageInfo pageInfo)
        {
            Topic = topic;
            PostsPerPage = posts;
            PageInfo = pageInfo;



        }
    }
}