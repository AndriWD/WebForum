using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebForum.Domain.Interfaces;
using WebForum.Models;

namespace WebForum.Infrastructure.DAL
{
    /// <summary>
    ///  Реалізація паттерна UnitOfWork
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        ApplicationDbContext db;
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="context">Екземпляр доступу до БД</param>
        public UnitOfWork(ApplicationDbContext context)
        {
            db = context;
        }

        //реалізація паттерну Singelton
        private Lazy<PostRepository> postRepository;
        private Lazy<TopicRepository> topicRepository;
        /// <summary>
        /// Колекція Дописів (реалізовано через Singelton)
        /// </summary>
        public PostRepository Posts
        {
            get
            {
                if (postRepository == null)
                    postRepository = new Lazy<PostRepository>(() => new PostRepository(db));
                return postRepository.Value;
            }
        }
        /// <summary>
        /// Колекція Тем (реалізовано через Singelton)
        /// </summary>
        public TopicRepository Topics
        {
            get
            {
                if (topicRepository == null)
                    topicRepository = new Lazy<TopicRepository>(() => new TopicRepository(db));
                return topicRepository.Value;
            }
        }

        private bool disposed = false;

        public void Dispose()
        {
            db.Dispose();
            GC.SuppressFinalize(this);
        }
        public virtual void Dispose(bool disposing)
        {
            if(this.disposed != true)
            {
                if (disposing == true)
                    db.Dispose();
                this.disposed = true;
            }
        }
        /// <summary>
        /// Збереження в БД
        /// </summary>
        public void Save()
        {
            db.SaveChanges();
        }
        
    }
}