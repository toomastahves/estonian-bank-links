namespace Pizza
{
    using System;
    using System.IO;
    using System.Reflection;
    using System.Text;
    using Org.BouncyCastle.Crypto;
    using Org.BouncyCastle.OpenSsl;
    using Org.BouncyCastle.Security;
    using Org.BouncyCastle.X509;

    public class Util
    {
        public static bool Verify(string certificatePath, string macstring, string signature, string encoding = "UTF-8")
        {
            object obj;
            using (TextReader reader = File.OpenText(certificatePath))
            {
                obj = new PemReader(reader).ReadObject();
            }
            ICipherParameters parameters = obj is X509Certificate
                                               ? ((X509Certificate) obj).GetPublicKey()
                                               : (ICipherParameters) obj;
            ISigner signer = SignerUtilities.GetSigner("SHA1withRSA");
            signer.Init(false, parameters);
            byte[] bytes = Encoding.GetEncoding(encoding).GetBytes(macstring);
            signer.BlockUpdate(bytes, 0, bytes.Length);
            return signer.VerifySignature(Convert.FromBase64String(signature));
        }

        public static string Sign(string privateKeyPath, string privateKeySecret, string macstring, string encoding = "ISO-8859-1")
        {
            AsymmetricCipherKeyPair asymmetricCipherKeyPair;
            using (StreamReader streamReader = File.OpenText(privateKeyPath))
            {
                asymmetricCipherKeyPair = (AsymmetricCipherKeyPair)new PemReader(streamReader, new Secret(privateKeySecret)).ReadObject();
            }
            ISigner signer = SignerUtilities.GetSigner("SHA1withRSA");
            signer.Init(true, asymmetricCipherKeyPair.Private);
            byte[] bytes = Encoding.GetEncoding(encoding).GetBytes(macstring);
            signer.BlockUpdate(bytes, 0, bytes.Length);
            return Convert.ToBase64String(signer.GenerateSignature());
        }

        public static string ToMacDataString(object signParameters, string[] parameterOrder, Enums.BankKey bank)
        {
            var stringBuilder = new StringBuilder();
            foreach (string str1 in parameterOrder)
            {
                foreach (FieldInfo fieldInfo in signParameters.GetType().GetFields())
                {
                    if (str1 == fieldInfo.Name)
                    {
                        var encoder = GetEncoder(bank);
                        var str2 = string.Format("{0:D3}{1}", encoder.CalculateLength(fieldInfo.GetValue(signParameters).ToString()), fieldInfo.GetValue(signParameters));
                        stringBuilder.Append(str2);
                    }
                }
            }
            return (stringBuilder).ToString();
        }

        public static PaymentEncoder GetEncoder(Enums.BankKey bank)
        {
            var encoding = Encoding.GetEncoding("ISO-8859-1");
            return new PaymentEncoder(encoding, (e, s) => s.Length);
        }
        public static string CreateReferenceNumber(string number)
        {
            var checkNumber = ComputeCheckDigit(number);
            return string.Format("{0}{1}", number, checkNumber);
        }
        public static int ComputeCheckDigit(string baseNumber)
        {
            var sum = 0;
            for (var index = baseNumber.Length - 1; index >= 0; index--)
            {
                sum += (baseNumber[index] - '0') * GetWeight(baseNumber.Length, index);
            }
            return (10 - sum % 10) % 10;
        }
        private static int GetWeight(int length, int index)
        {
            switch ((length - index) % 3)
            {
                case 0:
                    return 1;
                case 1:
                    return 7;
                case 2:
                    return 3;
                default:
                    return 0;
            }
        }
    }
}
