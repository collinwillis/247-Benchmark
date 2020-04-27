using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Benchmark.Business;
using Benchmark.Models;
using Microsoft.Ajax.Utilities;
using NLog;

namespace Benchmark.Controllers
{
    public class HomeController : Controller
    {
        private static Logger logger = LogManager.GetLogger("myAppLoggerrule");
        private IBusinessService _iservice;

        public HomeController(IBusinessService ibusinessService)
        {
            _iservice = ibusinessService;
        }


        public ActionResult index()
        {
            return View();
        }

        public ActionResult verseSearch()
        {
            return View(new Verse());
        }

        public ActionResult verseEntry()
        {
            return View();
        }

        public ActionResult insertVerse(Verse v)
        {
            logger.Info("Entering the Home Controller. insertVerse Method.");
            _iservice.insertVerse(v);
            logger.Info("Exit Home Controller. Insert Success!");
            
            return View("index");
        }

        public ActionResult onSearch(Verse v)
        {
            logger.Info("Entering the Home Controller. onSearch Method.");
            Verse returnedverse = _iservice.getText(v);
            logger.Info("Exit Home Controller. Search Success!");
            return PartialView("_theSearchedVerse", returnedverse);
        }

        //public ActionResult getVerse(Verse verse)
        //{
        //    Verse v = service.getText(verse);
            
        //}
    }
}