using BLL;
using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsWebApplication_MVC_Layer.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult Index()
        {
            var data = NewsService.Get();
            return View(data);
        }

        //______________________________Add Restaurant________________________

        [HttpGet]
        public ActionResult AddNews()
        {
            ViewBag.categories = CategoryService.Get();
            return View();
        }

        [HttpPost]
        public ActionResult AddNews(NewsDTO news)
        {
            if (ModelState.IsValid)
            {
                NewsService.Create(news);
                TempData["added"] = "A new news is added";
                return RedirectToAction("Index");
            }
            return View(news);
        }

        public ActionResult NewsDetails(int id)
        {
            var data = NewsService.Details(id);
            return View(data);
        }
        public ActionResult NewsDelete(int id)
        {
            NewsService.Delete(id);
            TempData["deleted"] = "Successfully deleted";
            return RedirectToAction("Index");

        }


        [HttpGet]
        public ActionResult UpdateNews(int id)
        {
            ViewBag.categories = CategoryService.Get();
            return View(NewsService.Details(id));
        }

        [HttpPost]
        public ActionResult UpdateNews(NewsDTO news, int id)
        {

            NewsService.Edit(news, id);
            TempData["updated"] = "News is updated";
            return RedirectToAction("Index");

        }

    }
}