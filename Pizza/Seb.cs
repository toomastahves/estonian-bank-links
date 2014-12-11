namespace Pizza
{
    public sealed class Seb : PizzaProvider
    {
        public override string ServiceUrl { get; set; }
        public override string ReturnUrl { get; set; }
        public override string CancelUrl { get; set; }
        public override string FileCert { get; set; }
        public override string FileKey { get; set; }
        public override string KeySecret { get; set; }
        public override string Encoding { get; set; }
        public override string SenderId { get; set; }
        public override string AccountNo { get; set; }
        public override string AccountName { get; set; }

        public override void SignPaymentRequest(ref PaymentRequest payment, int service = 1011)
        {
            var parameterOrder = new string[13]
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
                                        "VK_MSG",
                                        "VK_RETURN",
                                        "VK_CANCEL",
                                        "VK_DATETIME"
                                     };
            payment.SignParams = new RequestSignParams()
                                     {
                                         VK_SERVICE = service.ToString(),
                                         VK_VERSION = "008",
                                         VK_SND_ID = this.SenderId,
                                         VK_STAMP = payment.Stamp,
                                         VK_AMOUNT = string.Format(PizzaProvider.AmountFormatInfo, "{0:N2}", new object[1] { (object)payment.Amount }),
                                         VK_CURR = payment.Currency.ToString(),
                                         VK_ACC = this.AccountNo,
                                         VK_NAME = this.AccountName,
                                         VK_REF = payment.RefNum,
                                         VK_MSG = payment.Message,
                                         VK_CANCEL = this.CancelUrl,
                                         VK_RETURN = this.ReturnUrl,
                                         VK_DATETIME = this.DateTime
                                     };
            string str = Util.Sign(FileKey, KeySecret, Util.ToMacDataString(payment.SignParams, parameterOrder, Enums.BankKey.Seb), Encoding);
            payment.SignParams.VK_MAC = str;
            payment.ExtraParams = new ExtraParams
                                      {
                                          VK_ENCODING = Encoding,
                                          VK_LANG = payment.Language.ToString()
                                      };
        }

        public override bool VerifyPaymentResponse(PaymentResponse payment)
        {
            return Util.Verify(FileCert,
                               Util.ToMacDataString(payment.SignParams,
                               GetResponseParamOrder(payment.SignParams.VK_SERVICE), Enums.BankKey.Seb),
                               payment.Signature, Encoding);
        }
    }
}
