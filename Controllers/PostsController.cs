using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebForum.Domain.Models;
using WebForum.Models;
using WebForum.Infrastructure.DAL;
using Microsoft.AspNet.Identity;

namespace WebForum.Controllers
{
    /// <summary>
    /// Дописи
    /// </summary>
    public class PostsController : Controller
    {
        private UnitOfWork repository;
        private ApplicationDbContext db;
        /// <summary>
        /// Конструктор
        /// </summary>
        public PostsController()
        {
            db = new ApplicationDbContext();
            repository = new UnitOfWork(db);
        }
              
        // GET: Posts/Create
        /// <summary>
        /// Створення нового допису
        /// </summary>
        /// <param name="Id">Ідентифікатор</param>
        /// <returns>Форма створення нового допису</returns>
        [Authorize]
        public ActionResult Create(int? Id)
        {
            ViewBag.TopicId = (int)Id;
            return View();
        }

        // POST: Posts/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Додавання допису до БД
        /// </summary>
        /// <param name="post">Допис</param>
        /// <returns>Повернення на сторінку теми</returns>
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Text,TopicId")] Post post)
        {
            if (ModelState.IsValid)
            {
                post.TimeOfCreateOrLastUpdate = DateTime.Now;
                string currentUserId = HttpContext.User.Identity.GetUserId();
                ApplicationUser currentUser = db.Users.Find(currentUserId);
                if(currentUser != null)
                {
                    post.User = currentUser;
                    post.UserId = currentUserId;
                    post.User.Posts.Add(post);
                    post.Topic = await repository.Topics.GetItemAsync(post.TopicId);
                    post.Topic.Posts.Add(post);
                    repository.Posts.Create(post);
                    repository.Save();
                    return RedirectToAction("Details", "Topics", new { id = post.TopicId });
                }
                else
                {
                    ModelState.AddModelError("", "Будь ласка, авторизуйтеся, щоб додати повідомлення");
                }
                
            }           
            return View(post);
        }

        // GET: Posts/Edit/5
        /// <summary>
        /// Редагування допису
        /// </summary>
        /// <param name="id">Ідентифікатор</param>
        /// <returns>Форма створення нового допису</returns>
        [Authorize]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = await repository.Posts.GetItemAsync((int)id);
            if (post == null)
            {
                return HttpNotFound();
            }
            if (post.UserId == HttpContext.User.Identity.GetUserId())
            {
                return View(post);
            }

            return RedirectToAction("DeniedAccess", new { id = post.TopicId });

        }

        // POST: Posts/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Оновлення допису в БД
        /// </summary>
        /// <param name="post">Допис</param>
        /// <returns>Повернення на сторінку теми</returns>
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Text,TopicId,UserId")] Post post)
        {
            if (ModelState.IsValid)
            {
                post.TimeOfCreateOrLastUpdate = DateTime.Now;
                post.User = db.Users.Find(post.UserId);
                post.Topic = await repository.Topics.GetItemAsync(post.TopicId);
                repository.Posts.Update(post);
                repository.Save();
                return RedirectToAction("Details", "Topics", new { id = post.TopicId });
            }
           
            return View(post);
        }
        /// <summary>
        /// Доступ заборонено
        /// </summary>
        /// <param name="id">Ідентифікатор</param>
        /// <returns>Доступ заборонено</returns>
        public ActionResult DeniedAccess(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.TopicId = (int)id;
            return View();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
