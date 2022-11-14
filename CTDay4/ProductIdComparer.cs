using System.Diagnostics.CodeAnalysis;
namespace CTDay4
{
    internal class ProductIdComparer : EqualityComparer<Product>
    {
        public override bool Equals(Product? x, Product? y)
        {
            return x.Id == y.Id;
        }

        public override int GetHashCode([DisallowNull] Product obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
