using BLL;
using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsWebApplication_MVC_Layer.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            var data = CategoryService.Get();
            return View(data);
        }

        //______________________________Add Restaurant________________________

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(CategoryDTO  category)
        {
            if (ModelState.IsValid)
            {
                CategoryService.Create(category);
                TempData["added"] = "A new category is added";
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public ActionResult CategoryDetails(int id)
        {
            var data = CategoryService.Details(id);
            return View(data);
        }
        public ActionResult CategoryDelete(int id)
        {
            CategoryService.Delete(id);
            TempData["deleted"] = "Successfully deleted";
            return RedirectToAction("Index");
            
        }


        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            return View(CategoryService.Details(id));
        }

        [HttpPost]
        public ActionResult UpdateCategory(CategoryDTO category,int id)
        {
        
                CategoryService.Edit(category,id);
                TempData["updated"] = "Category is updated";
                return RedirectToAction("Index");
           
        }


    }
}