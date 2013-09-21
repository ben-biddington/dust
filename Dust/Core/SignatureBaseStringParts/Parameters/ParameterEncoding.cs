using System;

namespace Dust.Core.SignatureBaseStringParts.Parameters
{
    internal class ParameterEncoding
    {
        internal string Escape(string what)
        {
            return Uri.EscapeDataString(what ?? "");
        }
    }
}