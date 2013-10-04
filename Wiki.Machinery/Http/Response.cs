using System.IO;
using System.Net;

namespace Wiki.Machinery.Http
{
    internal class Response
    {
        private readonly HttpWebResponse _inner;
        private readonly string _body;

        internal Response(HttpWebResponse inner)
        {
            _inner = inner;

            using (var rdr = new StreamReader(inner.GetResponseStream()))
            {
                _body = rdr.ReadToEnd();
            }
        }

        public string Body
        {
            get { return _body; }
        }

        public HttpStatusCode StatusCode
        {
            get { return _inner.StatusCode; }
        }
    }
}