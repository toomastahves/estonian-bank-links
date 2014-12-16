using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPayment.Models
{
    public class PaymentRequest
    {
        public string Stamp { get; set; }
        public double Amount { get; set; }
        public string RefNum { get; set; }
        public string Message { get; set; }
        public string Language { get; set; }
        public string Currency { get; set; }
        public string BankKey { get; set; }
        public RequestSignParams SignParams { get; set; }
        public ExtraParams ExtraParams { get; set; }
    }
}