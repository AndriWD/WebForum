using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebForum.Domain.Models;
using WebForum.Infrastructure.DAL;
using WebForum.Models;
using WebForum.ViewModels;

namespace WebForum.Controllers
{
    /// <summary>
    /// Головна сторінка
    /// </summary>
    public class HomeController : Controller
    {
        private UnitOfWork repository;
        /// <summary>
        /// Конструктор
        /// </summary>
        public HomeController()
        {
            repository = new UnitOfWork(new ApplicationDbContext());
        }
        /// <summary>
        /// Головна сторінка
        /// </summary>
        /// <param name="page">Номер сторінки</param>
        /// <returns>Головна сторінка</returns>
        public ActionResult Index(int page = 1)
        {
            HomeIndexViewTopics viewModel = CreateViewModel(page);
            return View(viewModel);
        }
        /// <summary>
        /// Теми на головній сторінці
        /// </summary> 
        /// <param name="page">Номер Сторінки</param>
        /// <returns>Наповнення головної сторінки</returns>
        private HomeIndexViewTopics CreateViewModel(int page)
        {
            int pageSize = 10;
            PageInfo pageInfo = new PageInfo(page, pageSize, repository.Topics.Count());
            IEnumerable<Topic> topicsPerPage = repository.Topics.GetAllItems().Skip((page - 1) * pageSize).Take(pageSize);
            HomeIndexViewTopics viewModel = new HomeIndexViewTopics(topicsPerPage, pageInfo);
            return viewModel;
        } 
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}