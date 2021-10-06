using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebForum.Domain.Interfaces
{
    /// <summary>
    /// Контракт для реалізації паттерна UnitOfWork
    /// </summary>
    public interface IUnitOfWork
    {       
            /// <summary>
            /// Метод для очищення виділеної пам'яті
            /// </summary>
            void Dispose();
            /// <summary>
            /// Збереження в БД
            /// </summary>
            void Save();
            
      
    }
}