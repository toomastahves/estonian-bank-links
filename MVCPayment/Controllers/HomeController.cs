using MVCPayment.Models;
using System.Web.Mvc;

namespace MVCPayment.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            PaymentRequest payment = new PaymentRequest()
            {
                Stamp = "1",
                Amount = 2.0,
                Currency = "EUR",
                RefNum = Util.CreateReferenceNumber("1"),
                Message = "Tellimus",
                Language = "EST"
            };
            PizzaProvider bank = new Seb()
            {
                FileCert = @"\Certificates\my\bank_cert.pem",
                FileKey = @"\Certificates\my\user_key.pem",
                ReturnUrl = "http://localhost:2833/",
                CancelUrl = "http://localhost:2833/",
                SenderId = "uid517917",
                AccountNo = "EE871600161234567892",
                AccountName = "A B",
                ServiceUrl = "https://pangalink.net/banklink/seb-common",
                Encoding = "ISO-8859-1"
            };
            bank.SignPaymentRequest(ref payment);

            return View(payment);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}