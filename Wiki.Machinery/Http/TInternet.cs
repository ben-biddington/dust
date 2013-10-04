using System.Net;

namespace Wiki.Machinery.Http
{
    class TInternet
    {
        internal static Response Get(HttpWebRequest req)
        {
            try
            {
                return new Response((HttpWebResponse)req.GetResponse());
            }
            catch (WebException e)
            {
                return new Response((HttpWebResponse)e.Response);
            }
        }
    }
}