using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pizza.Web
{
    public partial class SebReturn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Step 4 - Get a payment info from bank
            var paymentResponse = new PaymentResponse(Request.Form);
        }
    }
}