using System;
using System.Collections.Generic;

namespace H3ml.Asset
{
    public interface IAssetProvider : IDisposable
    {
        string MakeKey(string url, Dictionary<string, string> attributes);
        object CreateObject(string url, Dictionary<string, string> attributes);
    }
}
