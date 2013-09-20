using System;

namespace Dust.Core
{
    internal class UrlEncoding
    {
        internal string Escape(string what)
        {
            return Uri.EscapeDataString(what);
        }
    }
}