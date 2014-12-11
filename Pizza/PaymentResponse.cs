namespace Pizza
{
    using System.Collections.Specialized;

    public class PaymentResponse
    {
        private readonly NameValueCollection _collection;

        public ResponseSignParams SignParams
        {
            get
            {
                return new ResponseSignParams
                           {
                               VK_SERVICE = _collection["VK_SERVICE"],
                               VK_VERSION = _collection["VK_VERSION"],
                               VK_SND_ID = _collection["VK_SND_ID"],
                               VK_REC_ID = _collection["VK_REC_ID"],
                               VK_STAMP = _collection["VK_STAMP"],
                               VK_T_NO = _collection["VK_T_NO"],
                               VK_AMOUNT = _collection["VK_AMOUNT"],
                               VK_CURR = _collection["VK_CURR"],
                               VK_REC_ACC = _collection["VK_REC_ACC"],
                               VK_REC_NAME = _collection["VK_REC_NAME"],
                               VK_SND_ACC = _collection["VK_SND_ACC"],
                               VK_SND_NAME = _collection["VK_SND_NAME"],
                               VK_REF = _collection["VK_REF"],
                               VK_MSG = _collection["VK_MSG"],
                               VK_T_DATE = _collection["VK_T_DATE"],
                               VK_ERROR_CODE = _collection["VK_ERROR_CODE"],
                               VK_MAC = _collection["VK_MAC"]
                           };
            }
        }

        public ExtraParams ExtraParams
        {
            get
            {
                return new ExtraParams
                           {
                               VK_CHARSET = _collection["VK_CHARSET"],
                               VK_LANG = _collection["VK_LANG"]
                           };
            }
        }

        public string Signature
        {
            get { return _collection["VK_MAC"]; }
        }

        public PaymentResponse(NameValueCollection collection)
        {
            _collection = collection;
        }
    }
}
