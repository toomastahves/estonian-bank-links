using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pizza.Web
{
    public partial class SebStart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Step 1 - Create a payment
            PaymentRequest payment = new PaymentRequest()
            {
                Stamp = "1",
                Amount = 2.0,
                Currency = Enums.Currency.EUR,
                RefNum = Util.CreateReferenceNumber("1"),
                Message = "Tellimus",
                Language = Enums.Language.EST
            };

            // Step 2 - Do bank settings
            PizzaProvider bank = new Seb()
            {
                FileCert = @"\Certificates\seb\bank_cert.pem",
                FileKey = @"\Certificates\seb\user_key.pem",
                ReturnUrl = "http://localhost:4306/Pizza.Web/SebReturn.aspx",
                CancelUrl = "http://localhost:4306/Pizza.Web/SebReturn.aspx",
                SenderId = "uid517315",
                AccountNo = "EE871600161234567892",
                AccountName = "A B",
                ServiceUrl = "https://pangalink.net/banklink/seb-common",
                Encoding = "ISO-8859-1"
            };

            // Step 3 - Sign a payment
            bank.SignPaymentRequest(ref payment);

            /*VK_SERVICE.Text = payment.SignParams.VK_SERVICE;
            VK_VERSION.Text = payment.SignParams.VK_VERSION;
            VK_SND_ID.Text = payment.SignParams.VK_SND_ID;
            VK_STAMP.Text = payment.SignParams.VK_STAMP;
            VK_AMOUNT.Text = payment.SignParams.VK_AMOUNT;
            VK_CURR.Text = payment.SignParams.VK_CURR;
            VK_ACC.Text = payment.SignParams.VK_ACC;
            VK_NAME.Text = payment.SignParams.VK_NAME;
            VK_REF.Text = payment.SignParams.VK_REF;
            VK_MSG.Text = payment.SignParams.VK_MSG;

            VK_RETURN.Text = payment.SignParams.VK_RETURN;
            VK_CANCEL.Text = payment.SignParams.VK_CANCEL;
            VK_DATETIME.Text = payment.SignParams.VK_DATETIME;

            VK_MAC.Text = payment.SignParams.VK_MAC;

            VK_LANG.Text = payment.ExtraParams.VK_LANG;
            VK_ENCODING.Text = payment.ExtraParams.VK_ENCODING;*/
            var paymentForm = new ClientSelfPostForm { ActionUrl = bank.ServiceUrl, Method = "POST" };
            paymentForm["VK_SERVICE"] = payment.SignParams.VK_SERVICE;
            paymentForm["VK_VERSION"] = payment.SignParams.VK_VERSION;
            paymentForm["VK_SND_ID"] = payment.SignParams.VK_SND_ID;
            paymentForm["VK_STAMP"] = payment.SignParams.VK_STAMP;
            paymentForm["VK_AMOUNT"] = payment.SignParams.VK_AMOUNT;
            paymentForm["VK_CURR"] = payment.SignParams.VK_CURR;
            paymentForm["VK_ACC"] = payment.SignParams.VK_ACC;
            paymentForm["VK_NAME"] = payment.SignParams.VK_NAME;
            paymentForm["VK_REF"] = payment.SignParams.VK_REF;
            paymentForm["VK_MSG"] = payment.SignParams.VK_MSG;
            paymentForm["VK_RETURN"] = payment.SignParams.VK_RETURN;
            paymentForm["VK_CANCEL"] = payment.SignParams.VK_CANCEL;
            paymentForm["VK_DATETIME"] = payment.SignParams.VK_DATETIME;
            paymentForm["VK_MAC"] = payment.SignParams.VK_MAC;
            paymentForm["VK_LANG"] = payment.ExtraParams.VK_LANG;
            paymentForm["VK_ENCODING"] = payment.ExtraParams.VK_ENCODING;

            HttpContext.Current.Response.Write(paymentForm.Build());

            // Step 4 - Send a payment
            //Button1.PostBackUrl = bank.ServiceUrl;
        }
    }
}