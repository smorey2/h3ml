using System.Collections.Generic;
using System.Linq;

namespace H3ml.Asset
{
    public static class AssetManager
    {
        readonly static List<IAssetProvider> _providers = new List<IAssetProvider>();

        public static void RegisterByConvention()
        {
        }

        public static IAssetProvider Find() => _providers.FirstOrDefault();
    }
}
