using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using WebForum.Domain.Models;

namespace WebForum.Models
{
    // В профиль пользователя можно добавить дополнительные данные, если указать больше свойств для класса ApplicationUser. Подробности см. на странице https://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Обратите внимание, что authenticationType должен совпадать с типом, определенным в CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Здесь добавьте утверждения пользователя
            return userIdentity;
        }
        //Добавлені залежності
        /// <summary>
        /// Теми створені користувачем
        /// </summary>
        public virtual ICollection<Topic> Topics  { get; set; }
        /// <summary>
        /// Дописи створені користувачем
        /// </summary>
        public virtual ICollection<Post> Posts { get; set; }

        public Topic Topic1
        {
            get => default;
            set
            {
            }
        }

        public ApplicationUser()
        {
            Topics = new List<Topic>();
            Posts = new List<Post>();
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Post> Posts { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

    }
}