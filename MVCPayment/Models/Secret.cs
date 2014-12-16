using Org.BouncyCastle.OpenSsl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPayment.Models
{
    public class Secret : IPasswordFinder
    {
        private string _secret;

        public Secret(string secret)
        {
            this._secret = secret;
        }

        public char[] GetPassword()
        {
            return this._secret == null ? (char[])null : this._secret.ToCharArray();
        }
    }
}