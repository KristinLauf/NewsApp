using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Skilaverkefni3.Models;

namespace Skilaverkefni3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            NewsRepository repository = new NewsRepository();
            var model = repository.GetAllNews();
            return View(model);
        }

        public ActionResult About()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit ( int? id )
        {
            if (id == null)
                return View("Not found");
            NewsRepository repository = new NewsRepository();
            News news = repository.GetNewsById(id.Value);
            return View(news);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection fromData)
        {
            NewsRepository repository = new NewsRepository();
            News n = repository.GetNewsById(id);
            if (n != null)
            {
                UpdateModel(n);
                repository.UpdateNews(n);
                return RedirectToAction("Index");
            }
            else
            {
                return View("NotFound");
            }
        }
        
        [HttpGet]
        public ActionResult Create()
        {
            return View(new News());
        }

        [HttpPost]
        public ActionResult Create(FormCollection formData)
        {
            News n = new News();
            UpdateModel(n);
            NewsRepository repository = new NewsRepository();
            repository.AddNews(n);
            return RedirectToAction("Index");
        }
    }
}
