namespace Pizza
{
    using System;
    using System.Globalization;

    public abstract class PizzaProvider
    {
        public abstract string ServiceUrl { get; }

        public abstract string ReturnUrl { get; set; }

        public abstract string CancelUrl { get; set; }

        public abstract string Login { get; set; }

        public abstract string FileCert { get; set; }

        public abstract string FileKey { get; set; }

        public abstract string KeySecret { get; set; }

        public abstract string Encoding { get; }

        public abstract string SenderId { get; set; }

        public abstract string AccountNo { get; set; }

        public abstract string AccountName { get; set; }

        public static IFormatProvider AmountFormatInfo
        {
            get
            {
                return new NumberFormatInfo
                           {
                               CurrencyDecimalDigits = 2,
                               NumberDecimalSeparator = "."
                           };
            }
        }

        public abstract void SignPaymentRequest(ref PaymentRequest payment, int service = 1001);

        public abstract bool VerifyPaymentResponse(PaymentResponse payment);

        protected virtual string[] GetResponseParamOrder(string response)
        {
            switch (response)
            {
                case "1101":
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
                                   "VK_T_DATE"
                               };
                case "1901":
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
