using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Dal;

namespace WebApplication3.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        StoreContext db = new StoreContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Details(int id)
        {
          var podzespol=  db.Podzespol.Find(id);
            return View(podzespol);
        
        }

        public ActionResult List(string genrename, string searchQuery = null)
        {
            var Podzespoly = db.Podzespoly.Include("Podzespoly1").Where(g => g.Name.ToUpper() == genrename.ToUpper()).Single();
            var podzespol = Podzespoly.Podzespoly1.Where(a => (searchQuery == null ||
                                                a.NazwaPodzespolu.ToLower().Contains(searchQuery.ToLower()) ||
                                                a.Producent.ToLower().Contains(searchQuery.ToLower())) &&
                                                !a.IsHidden).ToList();
            if (Request.IsAjaxRequest())
            {

                return PartialView("_ProductList", podzespol);
            }

            return View(podzespol);
        }
        [ChildActionOnly]
        [OutputCache(Duration =80000)]
        public ActionResult PodzespolyMenu()
        {
            var podzespoly = db.Podzespoly.ToList();
            return PartialView("_PodzespolyMenu",podzespoly);
        }
        public ActionResult PodzespolSuggestions(string term)
        {
            var podzespoly = this.db.Podzespol.Where(p => !p.IsHidden && p.NazwaPodzespolu.ToLower().Contains(term.ToLower())).Take(5).Select(p => new { label = p.NazwaPodzespolu }).ToList();
            return Json(podzespoly, JsonRequestBehavior.AllowGet);
        }
    }
}