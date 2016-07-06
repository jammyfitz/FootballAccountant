using System.Web.Mvc;
using System.Collections.Generic;
using FootballAccountant.Models;
using FootballAccountant.Services;
using System.Resources;
using FootballAccountant.Properties;

namespace FootballAccountant.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.DuePayment = GetDuePayment();

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

        public ActionResult Email()
        {
            SendEmail();

            return RedirectToAction("EmailConfirmation");
        }

        public ActionResult EmailConfirmation()
        {
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

        private Payment GetDuePayment()
        {
            var service = new FootballDataService();

            ViewBag.DuePaymentText = Resources.DuePaymentText;

            return service.GetDuePayment();
        }

        private void SendEmail()
        {
            var duePayment = GetDuePayment();

            var service = new FootballEmailService();

            service.SendEmail(duePayment);
        }
    }
}