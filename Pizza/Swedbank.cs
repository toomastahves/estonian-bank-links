namespace Pizza
{
  public sealed class Swedbank : PizzaProvider
  {
    public override string ServiceUrl
    {
      get
      {
        return "https://www.swedbank.ee/banklink";
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
      get
      {
        return "UTF-8";
      }
    }

    public override string SenderId { get; set; }

    public override string AccountNo { get; set; }

    public override string AccountName { get; set; }

    public override void SignPaymentRequest(ref PaymentRequest payment, int service = 1001)
    {
      string[] parameterOrder = new string[10]
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
      payment.SignParams = new RequestSignParams()
      {
        VK_SERVICE = service.ToString(),
        VK_VERSION = "008",
        VK_SND_ID = this.SenderId,
        VK_STAMP = payment.Stamp,
        VK_AMOUNT = string.Format(PizzaProvider.AmountFormatInfo, "{0:N2}", new object[1]
        {
          (object) payment.Amount
        }),
        VK_CURR = payment.Currency,
        VK_ACC = this.AccountNo,
        VK_NAME = this.AccountName,
        VK_REF = payment.RefNum,
        VK_MSG = payment.Message
      };
      string str = Util.Sign(this.FileKey, this.KeySecret, Util.ToMacDataString((object) payment.SignParams, parameterOrder), this.Encoding);
      payment.SignParams.VK_MAC = str;
      payment.ExtraParams = new ExtraParams()
      {
        VK_CHARSET = this.Encoding,
        VK_RETURN = this.ReturnUrl,
        VK_CANCEL = this.CancelUrl,
        VK_LANG = payment.Language
      };
    }

    public override bool VerifyPaymentResponse(PaymentResponse payment)
    {
      return Util.Verify(this.FileCert, Util.ToMacDataString((object) payment.SignParams, this.GetResponseParamOrder(payment.SignParams.VK_SERVICE)), payment.Signature, this.Encoding);
    }
  }
}
