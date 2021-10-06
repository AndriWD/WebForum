using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebForum.Domain.Interfaces;
using WebForum.Domain.Models;
using WebForum.Models;

namespace WebForum.Infrastructure.DAL
{
    /// <summary>
    /// Репозиторій дописів
    /// </summary>
    public class PostRepository : IRepository<Post>
    {
        private ApplicationDbContext db;
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="db">Екземпляр доступу до БД</param>
        public PostRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        /// <summary>
        /// Добавити допис до БД
        /// </summary>
        /// <param name="post">Допис</param>
        public void Create(Post post)
        {
            db.Posts.Add(post);
        }
        /// <summary>
        /// Добавити допис до БД асинхронно
        /// </summary>
        /// <param name="post"></param>
        public async void CreateAsync(Post post)
        {
            db.Posts.Add(post);
        }
        /// <summary>
        /// Видалити допис з БД
        /// </summary>
        /// <param name="id"></param>
        public void Delate(int id)
        {
            Post post = db.Posts.Find(id);
            if (post != null)
                db.Posts.Remove(post);
        }
        /// <summary>
        /// Видалити допис з БД асинхронно
        /// </summary>
        /// <param name="id"></param>
        public async void DelateAsync(int id)
        {
            Post post = await db.Posts.FindAsync(id);
            if (post != null)
                db.Posts.Remove(post);

        }
        /// <summary>
        /// Отримати всі дописи
        /// </summary>
        /// <returns>Всі дописи</returns>
        public IEnumerable<Post> GetAllItems()
        {
            return db.Posts.ToList();
        }
        /// <summary>
        /// Отримати всі дописи асинхронно
        /// </summary>
        /// <returns>Всі дописи</returns>
        public async Task<IEnumerable<Post>> GetAllItemsAsync()
        {
            return await db.Posts.ToListAsync();
        }
        /// <summary>
        /// Отримати допис за ідентифікатором
        /// </summary>
        /// <param name="id">Ідентифікатор</param>
        /// <returns>Допис</returns>
        public Post GetItem(int id)
        {
            return db.Posts.Find(id);
        }
        /// <summary>
        /// Отримати допис за ідентифікатором асинхронно
        /// </summary>
        /// <param name="id">Ідентифікатор</param>
        /// <returns>Допис</returns>
        public async Task<Post> GetItemAsync(int id)
        {
            return await db.Posts.FindAsync(id);
        }

        /// <summary>
        /// Оновити допис в БД
        /// </summary>
        /// <param name="post">Допис</param>
        public void Update(Post post)
        {
            db.Entry(post).State = EntityState.Modified;
        }
        /// <summary>
        /// Отримати кількість дописів
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
           return db.Posts.Count();
        }
        /// <summary>
        /// Задає скільки дописів потрібно пропустити і повертає всі інші
        /// </summary>
        /// <param name="count">Кількість дописів, що потрібно пропустити</param>
        /// <returns>Дописи</returns>
        public IEnumerable<Post> Skip(int count)
        {
            return db.Posts.Skip(count);
        }
        /// <summary>
        /// Отримати визначену кількість дописів
        /// </summary>
        /// <param name="count">Кількість дописів, що потрібно повернути</param>
        /// <returns>Дописи</returns>
        public IEnumerable<Post> Take(int count)
        {
            return db.Posts.Take(count);
        }

        
    }
}