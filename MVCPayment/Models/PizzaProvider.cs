using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace MVCPayment.Models
{
    public abstract class PizzaProvider
    {
        public abstract string ServiceUrl { get; set; }
        public abstract string ReturnUrl { get; set; }
        public abstract string CancelUrl { get; set; }
        public abstract string FileCert { get; set; }
        public abstract string FileKey { get; set; }
        public abstract string KeySecret { get; set; }
        public abstract string Encoding { get; set; }
        public abstract string SenderId { get; set; }
        public abstract string AccountNo { get; set; }
        public abstract string AccountName { get; set; }
        public string DateTime
        {
            get { return System.DateTime.Now.ToString("yyyy-MM-ddTHH:mm:sszz00"); }
        }
        public static IFormatProvider AmountFormatInfo
        {
            get
            {
                return new NumberFormatInfo
                {
                    CurrencyDecimalDigits = 2,
                    NumberDecimalSeparator = ".",
                    CurrencyGroupSeparator = string.Empty,
                    NumberGroupSeparator = string.Empty
                };
            }
        }
        public abstract void SignPaymentRequest(ref PaymentRequest payment, int service = 1011);
        protected virtual string[] GetResponseParamOrder(string response)
        {
            switch (response)
            {
                case "1111":
                    return new string[15]
                               {
                                   "VK_SERVICE",
                                   "VK_VERSION",
                                   "VK_SND_ID",
                                   "VK_REC_ID",
                                   "VK_STAMP",
                                   "VK_T_NO",
                                   "VK_AMOUNT",
                                   "VK_CURR",
                                   "VK_REC_ACC",
                                   "VK_REC_NAME",
                                   "VK_SND_ACC",
                                   "VK_SND_NAME",
                                   "VK_REF",
                                   "VK_MSG",
                                   "VK_T_DATETIME"
                               };
                case "1911":
                    return new string[7]
                               {
                                   "VK_SERVICE",
                                   "VK_VERSION",
                                   "VK_SND_ID",
                                   "VK_REC_ID",
                                   "VK_STAMP",
                                   "VK_REF",
                                   "VK_MSG"
                               };
                case "1902":
                    return new string[8]
                               {
                                   "VK_SERVICE",
                                   "VK_VERSION",
                                   "VK_SND_ID",
                                   "VK_REC_ID",
                                   "VK_STAMP",
                                   "VK_REF",
                                   "VK_MSG",
                                   "VK_ERROR_CODE"
                               };
                default:
                    throw new ArgumentException("unknown service");
            }
        }

    }
}