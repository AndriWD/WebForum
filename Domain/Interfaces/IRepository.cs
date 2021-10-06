using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace WebForum.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
                
            /// <summary>
            /// Отримати всі об'єкти даного типу
            /// </summary>
            /// <returns>Всі елементи заданого типу</returns>
            IEnumerable<T> GetAllItems();
            /// <summary>
            /// Отримати всі об'єкти даного типу асинхронно
            /// </summary>
            /// <returns>Всі елементи заданого типу</returns>
            Task<IEnumerable<T>> GetAllItemsAsync();
            /// <summary>
            /// Отримати конкретний об'єкт за ідентифікатором
            /// </summary>
            /// <param name="id">Ідентифікатор</param>
            /// <returns>Об'єкт типу T за ідентифікатором</returns>
            T GetItem(int id);
            /// <summary>
            /// Отримати конкретний об'єкт за ідентифікатором асинхронно
            /// </summary>
            /// <param name="id">Ідентифікатор</param>
            /// <returns>Об'єкт типу T за ідентифікатором</returns>
            Task<T> GetItemAsync(int id);
            /// <summary>
            /// Додати об'єкт типу T до БД
            /// </summary>
            /// <param name="item">Об'єкт типу T</param>
            void Create(T item);
            /// <summary>
            /// Додати об'єкт типу T до БД асинхронно
            /// </summary>
            /// <param name="item">Об'єкт типу T</param>
            void CreateAsync(T item);
            /// <summary>
            /// Оновити об'єкт типу T в БД
            /// </summary>
            /// <param name="item">Об'єкт типу T</param>
            void Update(T item);           
            /// <summary>
            /// Видалити об'єкт типу T з БД за ідентифікатором
            /// </summary>
            /// <param name="id">Ідентифікатор</param>
            void Delate(int id);
            /// <summary>
            /// Видалити об'єкт типу T з БД за ідентифікатором асинхронно
            /// </summary>
            /// <param name="id">Ідентифікатор</param>
            void DelateAsync(int id);
            /// <summary>
            /// Отримати кількість об'єктів
            /// </summary>
            /// <returns>Кількість об'єктів</returns>
            int Count();
            /// <summary>
            /// Пропустити задану кількість об'єктів
            /// </summary>
            /// <param name="count">Кількість об'єктів, що потрібно пропустити</param>
            /// <returns>Всі наступні об'єкти після пропущених</returns>
            IEnumerable<T> Skip(int count);
            /// <summary>
            /// Отримати визначену кількість об'єктів
            /// </summary>
            /// <param name="count">Кількість об'єктів, що потрібно повернути</param>
            /// <returns>Об'єкти в кількості, якій потрібно повернути</returns>
            IEnumerable<T> Take(int count);



    }
}