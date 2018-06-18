using _180530.Scraper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _180530.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {        
            LakewoodScoopScraper scraper = new LakewoodScoopScraper();
            return View(scraper.GetPosts());
        }                      
    }
}