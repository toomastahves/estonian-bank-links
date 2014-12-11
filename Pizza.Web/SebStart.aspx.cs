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
            PaymentRequest payment = new PaymentRequest
            {
                Stamp = "88",
                Amount = 33.66,
                Currency = "EUR",
                RefNum = "123",
                Message = "Porgandid",
                Language = "ENG"
            };

            // Step 2 - Do bank settings
            PizzaProvider bank = new Seb
            {
                //FileCert = Server.MapPath("~") + @"\Certificates\eyp_pub.pem",
                //FileCert = Server.MapPath("~") + @"\Certificates\bank_cert.pem",
                //FileKey = Server.MapPath("~") + @"\Certificates\kaupmees_priv.pem",
                //FileKey = Server.MapPath("~") + @"\Certificates\user_key.pem",
                FileKey = @"\Certificates\seb\user_key.pem",
                FileCert = @"\Certificates\seb\bank_cert.pem",
                ReturnUrl = "http://localhost:4306/Pizza.Web/SebReturn.aspx",
                CancelUrl = "http://localhost:4306/Pizza.Web/SebReturn.aspx",
                //KeySecret = "testime",
                SenderId = "uid517315",//"uid517917",//"testvpos",
                AccountNo = "EE871600161234567892",
                AccountName = "ÕIE MÄGER"
            };

            // Step 3 - Sign a payment
            bank.SignPaymentRequest(ref payment);

            VK_SERVICE.Text = payment.SignParams.VK_SERVICE;
            VK_VERSION.Text = payment.SignParams.VK_VERSION;
            VK_SND_ID.Text = payment.SignParams.VK_SND_ID;
            VK_STAMP.Text = payment.SignParams.VK_STAMP;
            VK_AMOUNT.Text = payment.SignParams.VK_AMOUNT;
            VK_CURR.Text = payment.SignParams.VK_CURR;
            VK_ACC.Text = payment.SignParams.VK_ACC;
            VK_NAME.Text = payment.SignParams.VK_NAME;
            VK_REF.Text = payment.SignParams.VK_REF;
            VK_MSG.Text = payment.SignParams.VK_MSG;
            VK_MAC.Text = payment.SignParams.VK_MAC;
            VK_RETURN.Text = payment.ExtraParams.VK_RETURN;
            VK_LANG.Text = payment.ExtraParams.VK_LANG;
            VK_CHARSET.Text = payment.ExtraParams.VK_CHARSET;

            // Step 4 - Send a payment
            Button1.PostBackUrl = bank.ServiceUrl;
        }
    }
}