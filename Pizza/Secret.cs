using Org.BouncyCastle.OpenSsl;

namespace Pizza
{
  internal class Secret : IPasswordFinder
  {
    private string _secret;

    public Secret(string secret)
    {
      this._secret = secret;
    }

    public char[] GetPassword()
    {
      return this._secret == null ? (char[]) null : this._secret.ToCharArray();
    }
  }
}
