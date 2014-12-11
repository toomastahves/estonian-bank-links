using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace Pizza
{
    public class ClientSelfPostForm
    {
        private readonly NameValueCollection _nvc = new NameValueCollection();

        public bool SafetyOn { get; set; }
        public string Encoding { get; set; }
        public string ActionUrl { get; set; }
        public string Method { get; set; }
        public string RedirectMsg { get; set; }

        public string this[string name]
        {
            get { return _nvc[name]; }
            set
            {
                _nvc.Remove(name);
                _nvc[name] = value;
            }
        }

        public string Build()
        {
            var sb = new StringBuilder();
            sb.Append("<html xmlns=\"http://www.w3.org/1999/xhtml\">");
            sb.Append("<head>");

            if (!string.IsNullOrEmpty(Encoding))
            {
                sb.AppendFormat("<meta http-equiv=\"Content-Type\" content=\"text/html; charset={0}\">", Encoding);
            }

            sb.Append("</head>");
            sb.Append("<body>");
            sb.AppendFormat("<form action =\"{0}\" method=\"{1}\">", ActionUrl, Method);

            foreach (string name in _nvc.Keys)
            {
                sb.AppendFormat("<input type=\"hidden\" name=\"{0}\" value=\"{1}\">", name, SafetyOn ? System.Web.HttpUtility.UrlEncode(_nvc[name]) : _nvc[name]);
            }

            sb.Append("<input type=\"submit\" value=\"Maksan\">");
            sb.Append("<br />");
            sb.Append(RedirectMsg);
            sb.Append("</form>");
            sb.Append("<script language=\"javascript\" type=\"text/javascript\">");
            sb.Append("document.forms[0].submit();");
            sb.Append("</script>");
            sb.Append("</body>");
            sb.Append("</html>");

            return sb.ToString();
        }
    }
}
