using System.Web.Mvc;
using System.Collections.Generic;
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

        public ActionResult Payments()
        {
            ViewBag.Payments = GetPayments();

            return View();
        }

        public ActionResult Charges()
        {
            ViewBag.Charges = GetCharges();

            return View();
        }

        private IList<Charge> GetCharges()
        {
            var service = new FootballDataService();

            return service.GetCharges();
        }

        private IList<Payment> GetPayments()
        {
            var service = new FootballDataService();

            return service.GetPayments();
        }
    }
}