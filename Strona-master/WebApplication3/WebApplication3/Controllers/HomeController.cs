using MvcSiteMapProvider.Caching;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Dal;
using WebApplication3.Infrastructure;
using WebApplication3.Models;
using WebApplication3.ViewModels;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        private StoreContext db = new StoreContext();
        // GET: Home
        public ActionResult Index()
        {
            var podzespoly = db.Podzespoly.ToList();
            ICacheProvider cache = new DefaultCacheProvider();
            List<Podzespol> newArrivals;
            if (cache.IsSet(Consts.NewItemsCacheKey))
            {
                newArrivals = cache.Get(Consts.NewItemsCacheKey) as List<Podzespol>;
            }
            else
            {
                 newArrivals = db.Podzespol.Where(a => !a.IsHidden).OrderByDescending(a => a.DateAdded).Take(3).ToList();
                cache.Set(Consts.NewItemsCacheKey, newArrivals, 30);
            }
           
            var bestsellers = db.Podzespol.Where(a => !a.IsHidden && a.IsBestseller).OrderBy(g => Guid.NewGuid()).Take(3).ToList();
            var vm = new HomeViewModel()
            {
                Bestsellers = bestsellers,
                NewArrivals = newArrivals,
                Podzespoly = podzespoly,
        };
            
            return View(vm);
        }
        public ActionResult StaticContent(string viewname)
        {
            return View(viewname);
        }
      
    }
}