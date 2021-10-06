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
    /// Репозиторій тем
    /// </summary>
    public class TopicRepository : IRepository<Topic>
    {
        private ApplicationDbContext db;
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="db">Екземпляр доступу до БД</param>
        public TopicRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        /// <summary>
        /// Добавити тему до БД
        /// </summary>
        /// <param name="topic">Тема</param>
        public void Create(Topic topic)
        {
            db.Topics.Add(topic);
        }
        /// <summary>
        /// Добавити тему до БД асинхронно
        /// </summary>
        /// <param name="topic"></param>
        public async void CreateAsync(Topic topic)
        {
            db.Topics.Add(topic);
        }
        /// <summary>
        /// Видалити тему з БД 
        /// </summary>
        /// <param name="id">Ідентифікатор</param>
        public void Delate(int id)
        {
            Topic topic = db.Topics.Find(id);
            if (topic != null)
                db.Topics.Remove(topic);
        }
        /// <summary>
        /// Видалити тему з БД асинхронно
        /// </summary>
        /// <param name="id">Ідентифікатор</param>
        public async void DelateAsync(int id)
        {
            Topic topic = await db.Topics.FindAsync(id);
            if (topic != null)
                db.Entry(topic).State = System.Data.Entity.EntityState.Deleted;
        }
        /// <summary>
        /// Отримати всі теми
        /// </summary>
        /// <returns>Всі теми</returns>
        public IEnumerable<Topic> GetAllItems()
        {
            //існує необхідність першими показувати теми, які є найновішими
            return db.Topics.OrderByDescending(t => t.TimeOfCreateOrLastUpdate).ToList();
        }
        /// <summary>
        /// Отримати всі теми асинхронно
        /// </summary>
        /// <returns>Всі теми</returns>
        public async Task<IEnumerable<Topic>> GetAllItemsAsync()
        {
            return await db.Topics.ToListAsync();
        }
        /// <summary>
        /// Отримати тему за ідентифікатором
        /// </summary>
        /// <param name="id">Ідентифікатор</param>
        /// <returns>Тема</returns>
        public Topic GetItem(int id)
        {
            return db.Topics.Find(id);
                         
        }
        /// <summary>
        /// Оновити тему в БД
        /// </summary>
        /// <param name="topic">Тема</param>
        public void Update(Topic topic)
        {
            db.Entry(topic).State = EntityState.Modified;
        }
        /// <summary>
        /// Отримати кількість тем
        /// </summary>
        /// <returns>Кількість тем</returns>
        public int Count()
        {
            return db.Topics.Count();
        }
        /// <summary>
        /// Задає скільки тем потрібно пропустити і повертає всі інші
        /// </summary>
        /// <param name="count">кількість тем, що потрібно повернути</param>
        /// <returns>Теми</returns>
        public IEnumerable<Topic> Skip(int count)
        {
            return db.Topics.Skip(count);
        }
        /// <summary>
        /// Задає скільки тем потрібно повернути
        /// </summary>
        /// <param name="count">Кількість тем, що потрібно повернути</param>
        /// <returns>Теми</returns>
        public IEnumerable<Topic> Take(int count)
        {
            return db.Topics.Take(count);
        }
        /// <summary>
        /// Отримати тему за ідентифікатором асинхронно
        /// </summary>
        /// <param name="id">Ідентифікатор</param>
        /// <returns>Тема</returns>
        public async Task<Topic> GetItemAsync(int id)
        {
            return await db.Topics.FindAsync(id);
        }
    }
}