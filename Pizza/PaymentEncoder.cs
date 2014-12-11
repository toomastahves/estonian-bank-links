using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pizza
{
    public class PaymentEncoder
    {
        private readonly Encoding _encoding;
        private readonly Func<Encoding, string, int> _lengthAlgorithm;

        public PaymentEncoder(Encoding encoding, Func<Encoding, string, int> lengthAlgorithm)
        {
            _encoding = encoding;
            _lengthAlgorithm = lengthAlgorithm;
        }

        public Encoding Encoding
        {
            get { return _encoding; }
        }

        public int CalculateLength(string value)
        {
            return _lengthAlgorithm(Encoding, value);
        }
    }
}
