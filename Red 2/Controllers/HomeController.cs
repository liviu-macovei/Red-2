using System;
using System.Linq;
using System.Web.Mvc;
using Red_2.Models;

namespace Red_2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var context = new TodoContext();
            var items = context.TodoItems.ToList();
            return View(items);
        }

        [HttpGet]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult New(TodoItem item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var context = new TodoContext();
                    context.TodoItems.Add(item);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Active()
        {
            var context = new TodoContext();
            var items = context.TodoItems.Where(x => x.IsDone == false).ToList();
            return View(items);
        }

        public ActionResult Completed()
        {
            var context = new TodoContext();
            var items = context.TodoItems.Where(x => x.IsDone).ToList();
            return View(items);
        }

        public ActionResult Details(int id)
        {
            var context = new TodoContext();
            var item = context.TodoItems.FirstOrDefault(x => x.Id == id);
            return View(item);
        }

        public ActionResult CheckDone(int id)
        {
            var context = new TodoContext();
            var item = context.TodoItems.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                item.IsDone = !item.IsDone;
                context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}