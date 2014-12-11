namespace Pizza
{
    public sealed class Seb : PizzaProvider
    {
        public override string ServiceUrl
        {
            get { 
                //return "https://www.seb.ee/cgi-bin/dv.sh/un3min.r";
                return "https://pangalink.net/banklink/seb-common"; 
            }
        }

        public override string ReturnUrl { get; set; }

        public override string CancelUrl { get; set; }

        public override string Login { get; set; }

        public override string FileCert { get; set; }

        public override string FileKey { get; set; }

        public override string KeySecret { get; set; }

        public override string Encoding
        {
            get { return "UTF-8"; }
        }

        public override string SenderId { get; set; }

        public override string AccountNo { get; set; }

        public override string AccountName { get; set; }

        public override void SignPaymentRequest(ref PaymentRequest payment, int service = 1001)
        {
            var parameterOrder = new string[10]
                                     {
                                         "VK_SERVICE",
                                         "VK_VERSION",
                                         "VK_SND_ID",
                                         "VK_STAMP",
                                         "VK_AMOUNT",
                                         "VK_CURR",
                                         "VK_ACC",
                                         "VK_NAME",
                                         "VK_REF",
                                         "VK_MSG"
                                     };
            payment.SignParams = new RequestSignParams
                                     {
                                         VK_SERVICE = service.ToString(),
                                         VK_VERSION = "008",
                                         VK_SND_ID = SenderId,
                                         VK_STAMP = payment.Stamp,
                                         VK_AMOUNT = string.Format(AmountFormatInfo, "{0:N2}", new object[1]
                                                                                                   {
                                                                                                       payment.Amount
                                                                                                   }),
                                         VK_CURR = payment.Currency,
                                         VK_ACC = AccountNo,
                                         VK_NAME = AccountName,
                                         VK_REF = payment.RefNum,
                                         VK_MSG = payment.Message
                                     };
            string str = Util.Sign(FileKey, KeySecret, Util.ToMacDataString(payment.SignParams, parameterOrder),
                                   Encoding);
            payment.SignParams.VK_MAC = str;
            payment.ExtraParams = new ExtraParams
                                      {
                                          VK_CHARSET = Encoding,
                                          VK_RETURN = ReturnUrl,
                                          VK_CANCEL = CancelUrl,
                                          VK_LANG = payment.Language
                                      };
        }

        public override bool VerifyPaymentResponse(PaymentResponse payment)
        {
            return Util.Verify(FileCert,
                               Util.ToMacDataString(payment.SignParams, 
                               GetResponseParamOrder(payment.SignParams.VK_SERVICE)),
                               payment.Signature, Encoding);
        }
    }
}
