using System.Web.Mvc;
using System.Collections.Generic;
using FootballAccountant.Models;
using FootballAccountant.Services;
using FootballAccountant.Properties;
using System.Linq;

namespace FootballAccountant.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.DuePayment = GetDuePayment();
            ViewBag.DueCancellations = GetDueCancellations();
            ViewBag.UnsettledCancellations = GetUnsettledCancellations();

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

        public ActionResult Cancellations()
        {
            ViewBag.DueCancellations = GetUnclaimedCancellations();

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

        private IList<Cancellation> GetUnclaimedCancellations()
        {
            var service = new FootballDataService();

            return service.GetUnclaimedCancellations();
        }

        private IList<Cancellation> GetUnsettledCancellations()
        {
            var service = new FootballDataService();
            var unsettledCancellations = service.GetUnsettledCancellations();

            ViewBag.UnsettledCancellationText = Resources.UnsettledCancellationText;

            if(!unsettledCancellations.Any())
            {
                ViewBag.UnsettledCancellationText = Resources.NoUnsettledCancellations;
            }

            return unsettledCancellations;
        }

        private Payment GetDuePayment()
        {
            var service = new FootballDataService();
            var duePayment = service.GetDuePayment();

            ViewBag.DuePaymentText = Resources.DuePaymentText;

            if (duePayment == null)
            {
                ViewBag.DuePaymentText = Resources.NoDuePayment;
            }

            return duePayment;
        }

        private IList<Cancellation> GetDueCancellations()
        {
            var service = new FootballDataService();
            var dueCancellations = service.GetUnclaimedCancellations();

            ViewBag.DueCancellationText = Resources.DueCancellationText;

            if (!dueCancellations.Any())
            {
                ViewBag.DueCancellationText = Resources.NoDueCancellation;
            }

            return dueCancellations;
        }

        private void SendEmail()
        {
            var duePayment = GetDuePayment();
            var dueCancellations = GetDueCancellations();
            var unsettledCancellations = GetUnsettledCancellations();

            var service = new FootballEmailService();

            service.SendEmail(duePayment, dueCancellations, unsettledCancellations);
        }
    }
}