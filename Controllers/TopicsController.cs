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
using WebForum.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using System.Threading;

namespace WebForum.Controllers
{
    /// <summary>
    /// Теми
    /// </summary>
    public class TopicsController : Controller
    {
        private UnitOfWork repository;
        private ApplicationDbContext db;
       /// <summary>
       /// Конструктор
       /// </summary>
        public TopicsController()
        {
            db = new ApplicationDbContext();
            repository = new UnitOfWork(db);
        }

        // GET: Topics/Details/5
        /// <summary>
        /// Сторінка теми
        /// </summary>
        /// <param name="id">Ідентифікатор</param>
        /// <param name="page">Номер сторінки</param>
        /// <returns>Сторінка теми</returns>
        public async Task<ActionResult> Details(int? id, int page = 1)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Topic topic = await repository.Topics.GetItemAsync((int)id);
            if (topic == null)
            {
                return HttpNotFound();
            }

            TopicsDetailsViewTopicPosts viewModel = CreateViewModel(topic, page);

            return View(viewModel);
        }
        /// <summary>
        /// Наповнення сторінки теми
        /// </summary>
        /// <param name="topic">Тема</param>
        /// <param name="page">Номер сторінки</param>
        /// <returns>Наповнення сторінки теми</returns>
        private TopicsDetailsViewTopicPosts CreateViewModel(Topic topic, int page)
        {
            int pageSize = 10;
            PageInfo pageInfo = new PageInfo(page, pageSize, topic.Posts.Count);
            IEnumerable<Post> postsPerPage = topic.Posts.Skip((page-1) * pageSize).Take(pageSize);
            TopicsDetailsViewTopicPosts viewModel = new TopicsDetailsViewTopicPosts(topic, postsPerPage, pageInfo);
            return viewModel;
        }

        // GET: Topics/Create
        /// <summary>
        /// Створення нової теми
        /// </summary>
        /// <returns>Форма створення теми</returns>
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Topics/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Добавлення нової теми в БД
        /// </summary>
        /// <param name="topic">Тема</param>
        /// <returns>Повертає на сторінку теми</returns>
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Title,TextOfTopic")] Topic topic)
        {
            if (ModelState.IsValid)
            {
                topic.TimeOfCreateOrLastUpdate = DateTime.Now;
                string currentUserId = HttpContext.User.Identity.GetUserId();                
                ApplicationUser currentUser = await db.Users.FirstOrDefaultAsync(u => u.Id == currentUserId);
                if(currentUser != null)
                {
                    topic.UserId = currentUserId;
                    topic.AuthorTopic = currentUser;
                    topic.Posts = new List<Post>();
                    repository.Topics.Create(topic);
                    repository.Save();
                    return RedirectToAction("Index", "Home");
                }                               
            }

            return View(topic);
        }

        // GET: Topics/Edit/5
        /// <summary>
        /// Редагування теми
        /// </summary>
        /// <param name="id">Ідентифікатор</param>
        /// <returns>Форма редагування теми</returns>
        [Authorize]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Topic topic = await db.Topics.FindAsync(id);
            if (topic == null)
            {
                return HttpNotFound();
            }           
            if(topic.UserId == HttpContext.User.Identity.GetUserId())
            {
                return View(topic);
            }

            
            return RedirectToAction("DeniedAccess", new { id = id});

        }

        // POST: Topics/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Оновити тему в БД
        /// </summary>
        /// <param name="topic">Тема</param>
        /// <returns>Повернення на сторінку теми</returns>
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Title,TextOfTopic,UserId")] Topic topic)
        {
            
            if (ModelState.IsValid)
            {
                topic.TimeOfCreateOrLastUpdate = DateTime.Now;
                topic.AuthorTopic = db.Users.Find(topic.UserId);
                topic.Posts = repository.Posts.GetAllItems().Where(p => p.TopicId == topic.Id).ToList();
                repository.Topics.Update(topic);
                repository.Save();
                               
                return RedirectToAction("Details", new { id = topic.Id});
            }
            else
            {                        
                ModelState.AddModelError("", "Будь ласка, авторизуйтеся, щоб додати повідомлення");              
            }
            return View(topic);
        }
        /// <summary>
        /// Доступ заборонений
        /// </summary>
        /// <param name="id">Ідентифікатор</param>
        /// <returns>Доступ забороненний</returns>
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
