using System.Collections.Immutable;
using System.Security.Cryptography;

namespace MugShop.Helpers
{
    public class SKUGenerator
    {
        public  string GenerateSKU(string name, string color, string category)
        {
            var midCategory = category.Length % 2;

            var categoryCode = string.Concat(category.AsSpan(0,1), category.AsSpan(midCategory, 1));
            var nameCode = string.Concat(name.AsSpan(0, 1), name.AsSpan(name.Length - 1, 1));
            var colorCode = string.Concat(color.AsSpan(0, 1), color.AsSpan(color.Length - 1, 1));

            return $"{categoryCode}-{nameCode}-{colorCode}";
        }
    }
}
