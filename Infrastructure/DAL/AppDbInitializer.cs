using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebForum.Domain.Models;
using WebForum.Models;

namespace WebForum.Infrastructure.DAL
{
    /// <summary>
    /// Ініціалізація тестової БД
    /// </summary>
    public class AppDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        
        protected override void Seed(ApplicationDbContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            //Додаємо користуачів
            var user1 = new ApplicationUser() { UserName = "user1@gmail.com", Email = "user1@gmail.com" };
            var result1 = userManager.Create(user1, "123aA8-1");

            var user2 = new ApplicationUser() { UserName = "user2@gmail.com", Email = "user2@gmail.com" };
            var result2 = userManager.Create(user2, "123aA8-2");

            var user3 = new ApplicationUser() { UserName = "user3@gmail.com", Email = "user3@gmail.com" };
            var result3 = userManager.Create(user3, "123aA8-3");

            var user4 = new ApplicationUser() { UserName = "user4@gmail.com", Email = "user4@gmail.com" };
            var result4 = userManager.Create(user4, "123aA8-4");

            var user5 = new ApplicationUser() { UserName = "user5@gmail.com", Email = "user5@gmail.com" };
            var result5 = userManager.Create(user5, "123aA8-5");

            context.SaveChanges();

            //Користувачі
            user1 = context.Users.FirstOrDefault(u => u.Email == "user1@gmail.com");
            user2 = context.Users.FirstOrDefault(u => u.Email == "user2@gmail.com");
            user3 = context.Users.FirstOrDefault(u => u.Email == "user3@gmail.com");
            user4 = context.Users.FirstOrDefault(u => u.Email == "user4@gmail.com");
            user5 = context.Users.FirstOrDefault(u => u.Email == "user5@gmail.com");

            //Добавляємо теми
            var topic1 = new Topic() { Title = "Тема №1", TextOfTopic = "Дуже важливе питання №1, яке потребує розгляду на форумі" };
            topic1.UserId = user1.Id;
            topic1.AuthorTopic = user1;
            topic1.TimeOfCreateOrLastUpdate = DateTime.Now;
            user1.Topics.Add(topic1);
            

            var topic2 = new Topic() {Title = "Тема №2", TextOfTopic = "Дуже важливе питання №2, яке потребує розгляду на форумі" };
            topic2.UserId = user2.Id;
            topic2.AuthorTopic = user2;
            topic2.TimeOfCreateOrLastUpdate = DateTime.Now;
            user2.Topics.Add(topic2);

            var topic3 = new Topic() {Title = "Тема №3", TextOfTopic = "Дуже важливе питання №3, яке потребує розгляду на форумі" };
            topic3.UserId = user3.Id;
            topic3.AuthorTopic = user3;
            topic3.TimeOfCreateOrLastUpdate = DateTime.Now;
            user3.Topics.Add(topic3);

            var topic4 = new Topic() {Title = "Тема №4", TextOfTopic = "Дуже важливе питання №4, яке потребує розгляду на форумі" };
            topic4.UserId = user4.Id;
            topic4.AuthorTopic = user4;
            topic4.TimeOfCreateOrLastUpdate = DateTime.Now;
            user4.Topics.Add(topic4);

            var topic5 = new Topic() {Title = "Тема №5", TextOfTopic = "Дуже важливе питання №5, яке потребує розгляду на форумі" };
            topic5.UserId = user5.Id;
            topic5.AuthorTopic = user5;
            topic5.TimeOfCreateOrLastUpdate = DateTime.Now;
            user5.Topics.Add(topic5);

            var topic6 = new Topic() {Title = "Тема №6", TextOfTopic = "Дуже важливе питання №6, яке потребує розгляду на форумі" };
            topic6.UserId = user1.Id;
            topic6.AuthorTopic = user1;
            topic6.TimeOfCreateOrLastUpdate = DateTime.Now;
            user1.Topics.Add(topic6);

            context.Topics.Add(topic1);
            context.Topics.Add(topic2);
            context.Topics.Add(topic3);
            context.Topics.Add(topic4);
            context.Topics.Add(topic5);
            context.Topics.Add(topic6);
            context.SaveChanges();

            //Теми
            topic1 = context.Topics.FirstOrDefault(t => t.Title == "Тема №1");
            topic2 = context.Topics.FirstOrDefault(t => t.Title == "Тема №2");
            topic3 = context.Topics.FirstOrDefault(t => t.Title == "Тема №3");
            topic4 = context.Topics.FirstOrDefault(t => t.Title == "Тема №4");
            topic5 = context.Topics.FirstOrDefault(t => t.Title == "Тема №5");
            topic6 = context.Topics.FirstOrDefault(t => t.Title == "Тема №6");

            //Створюємо нові пости
            var post1 = new Post() {Text = "Повідомлення №1" };
            post1.TimeOfCreateOrLastUpdate = DateTime.Now;
            post1.TopicId = topic1.Id;
            post1.Topic = topic1;
            topic1.Posts.Add(post1);
            post1.UserId = user1.Id;
            post1.User = user1;
            user1.Posts.Add(post1);
            context.Posts.Add(post1);

            var post2 = new Post() {Text = "Повідомлення №2" };
            post2.TimeOfCreateOrLastUpdate = DateTime.Now;
            post2.TopicId = topic2.Id;
            post2.Topic = topic2;
            topic2.Posts.Add(post2);
            post2.UserId = user2.Id;
            post2.User = user2;
            user2.Posts.Add(post2);
            context.Posts.Add(post2);

            var post3 = new Post() {Text = "Повідомлення №3" };
            post3.TimeOfCreateOrLastUpdate = DateTime.Now;
            post3.TopicId = topic3.Id;
            post3.Topic = topic3;
            topic3.Posts.Add(post3);
            post3.UserId = user3.Id;
            post3.User = user3;
            user3.Posts.Add(post3);
            context.Posts.Add(post3);

            var post4 = new Post() {Text = "Повідомлення №4" };
            post4.TimeOfCreateOrLastUpdate = DateTime.Now;
            post4.TopicId = topic4.Id;
            post4.Topic = topic4;
            topic4.Posts.Add(post4);
            post4.UserId = user4.Id;
            post4.User = user4;
            user4.Posts.Add(post4);
            context.Posts.Add(post4);

            var post5 = new Post() {Text = "Повідомлення №5" };
            post5.TimeOfCreateOrLastUpdate = DateTime.Now;
            post5.TopicId = topic5.Id;
            post5.Topic = topic5;
            topic5.Posts.Add(post5);
            post5.UserId = user5.Id;
            post5.User = user5;
            user5.Posts.Add(post5);
            context.Posts.Add(post5);

            var post6 = new Post() {Text = "Повідомлення №6" };
            post6.TimeOfCreateOrLastUpdate = DateTime.Now;
            post6.TopicId = topic3.Id;
            post6.Topic = topic3;
            topic3.Posts.Add(post1);
            post6.UserId = user4.Id;
            post6.User = user4;
            user4.Posts.Add(post6);
            context.Posts.Add(post6);

            var post7 = new Post() {Text = "Повідомлення №7" };
            post7.TimeOfCreateOrLastUpdate = DateTime.Now;
            post7.TopicId = topic2.Id;
            post7.Topic = topic2;
            topic2.Posts.Add(post7);
            post7.UserId = user5.Id;
            post7.User = user5;
            user5.Posts.Add(post7);
            context.Posts.Add(post7);

            var post8 = new Post() {Text = "Повідомлення №8" };
            post8.TimeOfCreateOrLastUpdate = DateTime.Now;
            post8.TopicId = topic4.Id;
            post8.Topic = topic4;
            topic4.Posts.Add(post8);
            post8.UserId = user1.Id;
            post8.User = user1;
            user1.Posts.Add(post8);
            context.Posts.Add(post8);

            var post9 = new Post() {Text = "Повідомлення №9" };
            post9.TimeOfCreateOrLastUpdate = DateTime.Now;
            post9.TopicId = topic5.Id;
            post9.Topic = topic5;
            topic5.Posts.Add(post9);
            post9.UserId = user2.Id;
            post9.User = user2;
            user2.Posts.Add(post9);
            context.Posts.Add(post9);

            var post10 = new Post() {Text = "Повідомлення №10" };
            post10.TimeOfCreateOrLastUpdate = DateTime.Now;
            post10.TopicId = topic1.Id;
            post10.Topic = topic1;
            topic1.Posts.Add(post10);
            post10.UserId = user4.Id;
            post10.User = user4;
            user4.Posts.Add(post10);
            context.Posts.Add(post10);

            var post11 = new Post() {Text = "Повідомлення №11" };
            post11.TimeOfCreateOrLastUpdate = DateTime.Now;
            post11.TopicId = topic3.Id;
            post11.Topic = topic3;
            topic3.Posts.Add(post11);
            post11.UserId = user3.Id;
            post11.User = user3;
            user3.Posts.Add(post11);
            context.Posts.Add(post11);

            var post12 = new Post() {Text = "Повідомлення №12" };
            post12.TimeOfCreateOrLastUpdate = DateTime.Now;
            post12.TopicId = topic4.Id;
            post12.Topic = topic4;
            topic4.Posts.Add(post12);
            post12.UserId = user2.Id;
            post12.User = user2;
            user2.Posts.Add(post12);
            context.Posts.Add(post12);

            var post13 = new Post() {Text = "Повідомлення №13" };
            post13.TimeOfCreateOrLastUpdate = DateTime.Now;
            post13.TopicId = topic5.Id;
            post13.Topic = topic5;
            topic5.Posts.Add(post13);
            post13.UserId = user3.Id;
            post13.User = user3;
            user3.Posts.Add(post13);
            context.Posts.Add(post13);

            var post14 = new Post() {Text = "Повідомлення №14" };
            post14.TimeOfCreateOrLastUpdate = DateTime.Now;
            post14.TopicId = topic2.Id;
            post14.Topic = topic2;
            topic2.Posts.Add(post14);
            post14.UserId = user3.Id;
            post14.User = user3;
            user3.Posts.Add(post14);
            context.Posts.Add(post14);


            context.SaveChanges();

        }
    }
}