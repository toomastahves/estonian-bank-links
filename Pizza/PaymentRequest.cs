namespace Pizza
{
  public class PaymentRequest
  {
      public string Stamp { get; set; }
      public double Amount { get; set; }
      public string RefNum { get; set; }
      public string Message { get; set; }
      public Enums.Language Language { get; set; }
      public Enums.Currency Currency { get; set; }
      public Enums.BankKey BankKey { get; set; }
      public RequestSignParams SignParams { get; set; }
      public ExtraParams ExtraParams { get; set; }
  }
}
