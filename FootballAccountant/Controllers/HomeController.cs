using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;

using System.Web.Mvc;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using System;
using FootballAccountant.Models;
using FootballAccountant.Services;

namespace FootballAccountant.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Move()
        {
            ViewBag.Message = "Move MP3s";

            return View();
        }

        public ActionResult Charges()
        {
            ViewBag.FootballData = GetFootballData();
            ViewBag.Message = "Your contact page.";

            return View();
        }

        private IList<Charge> GetFootballData()
        {
            var service = new FootballDataService();

            return service.GetCharges();
        }
    }
}