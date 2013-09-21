using System;

namespace Dust.Core.SignatureBaseStringParts
{
    internal class UrlEncoding
    {
        internal string Escape(string what)
        {
            return Uri.EscapeDataString(what ?? "");
        }
    }
}