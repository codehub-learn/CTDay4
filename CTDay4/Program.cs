using CTDay4;

List<string> products = new List<string>() { "Laptop", "Tablet", "Mouse", "Keyboard" };
IEnumerable<string> productsfroml = products
    .Where(product => product.StartsWith('L') && product.EndsWith('p'));

IEnumerable<string> productStrings = Product.Products
    .Select(product => product.ToString().ToLower());

IEnumerable<string> productStringsQ = from product in Product.Products
                                      select product.ToString().ToLower();

List<string> productsstringlist = productStrings.ToList();

List<char> charslist = new() { 'a', 'b', 'c', 'd' };
IEnumerable<char> charsQuery = charslist;
charslist.Remove('b');
foreach (char c in charslist)
{
    Console.WriteLine(c);
}

var ProductNamePrice = Product.Products
    .Select(p => new Product() { Id = p.Id, Name = p.Name })
    .ToList();

var AnonymousProducts = Product.Products
    .Select(p => new { Id = p.Id, Name = p.Name }).ToList();


var AnonymousProducts2 = Product.Products
    .Select(p => new { p.Id, p.Name })
    .OrderByDescending(p => p.Name)
    .ThenByDescending(p => p.Id)
    .ToList();

var AnonymousProductsQ = (from p in Product.Products
                          select new { p.Id, p.Name})
                         .ToList();

var manufacturers = new[]
{
    new
    {
    CompanyName = "ThreeStars",
    ProductSeries = new[] {"Universe", "Nebula"}
    },
    new
    {
    CompanyName = "Watermelon",
    ProductSeries = new[] {"uPhone", "uPad"}
    }
};

List<string> ProductSerieses = 
    manufacturers
    .SelectMany(manufacturer => manufacturer.ProductSeries)
    .ToList();

var filteredProducts = Product.Products
    .Where(p => p.Color == "Black" && p.Name.StartsWith('u'));

var filteredProductsQ = (from p in Product.Products
                         where p.Color == "Black" && p.Name.StartsWith('u')
                         select p).ToList();

var filteredProducts2 = Product.Products
    .Where(p => p.Color == "Black" && p.Name.StartsWith('u'))
    .Select(p => p.ToString())
    .OrderBy(p => p)
    .ToList();

Product blackuphone = Product.Products.Where(p => p.Name == "uPhone X" && p.Color == "Black").First();
Product aUphone = Product.Products.Where(p => p.Name == "uPhone X").First();

try
{
    Product golduPhone = Product.Products.Where(p => p.Name == "uPhone X" && p.Color == "Gold").First();
}
catch (InvalidOperationException ex)
{
    Console.WriteLine(ex.Message);
}

Product? golduPhoneOrNull = 
    Product.Products.Where(p => p.Name == "uPhone X" && p.Color == "Gold")
    .FirstOrDefault();

Product? golduPhoneOrNull2 =
    Product.Products.LastOrDefault(p => p.Name == "uPhone X" && p.Color == "Gold");

Product blackuphone2 = Product.Products.Where(p => p.Name == "uPhone X" && p.Color == "Black").Single();
Product? blackuphone2orNull = Product.Products.Where(p => p.Name == "uPhone X" && p.Color == "Black").SingleOrDefault();
Product blackuphone3 = Product.Products.Where(p => p.Name == "uPhone X" && p.Color == "Black").Single();

List<Product> First2Products = Product.Products
    .OrderBy(p => p.Id)
    .Take(2)
    .ToList();

List<Product> TakeWhile = Product.Products
    .TakeWhile(p => p.Name == "uPhone X")
    .ToList();

List<Product> Skip = Product.Products
    .Skip(3)
    .ToList();

List<Product> SkipWhile = Product.Products
    .SkipWhile(p => p.Name == "uPhone X")
    .ToList();

List<string> Distinct = Product.Products
    .Select(p => p.Color)
    .Distinct()
    .ToList();

bool AreAllUProducts = Product.Products.All(p => p.Name.StartsWith('u'));
bool AreAllProductsBlack = Product.Products.All(p => p.Color == "Black");

bool AreThereAnyBlack = Product.Products.Any(p => p.Color == "Black");

bool Contains = Product.Products.Select(Product => Product.Name).Contains("uPad Air");

Product newProduct = new Product()
{
    Id = 1,
    Name = "uPhone X",
    Color = "Black",
    Price = 1200.99m,
    Cost = 800.10m
};

Product prodFromCollection = Product.Products.First();

bool ContainsRefFalse = Product.Products.Contains(newProduct);
bool ContainsRefTrue = Product.Products.Contains(prodFromCollection);

bool ContainsRefWithIDCompaper = Product.Products.Contains(newProduct, new ProductIdComparer());

List<int> ints1 = new() { 1, 2, 3 };
List<int> ints2 = new() { 1, 2, 3 };

bool CompareSequences = ints1.SequenceEqual(ints2);

bool sequenceEqualRef = Product.Products.SequenceEqual(Product.ProductsCopy, new ProductIdComparer());

var groupBy = Product.Products.GroupBy(p => p.Color).Where(p => p.Count() > 1).ToList();

var groupByQ = (from p in Product.Products
                group p by p.Color
               into pByColor
                where pByColor.Count() > 1
                select pByColor)
               .ToList();

var sumOfPrices = Product.Products.Sum(p => p.Price);
var minPrice = Product.Products.Min(p => p.Price);
var maxPrice = Product.Products.Max(p => p.Price);
var averagePrice = Product.Products.Average(p => p.Price);
var CountofProducts = Product.Products.Count();
var CountofUPads = Product.Products.Count(p => p.Name.StartsWith("uPad"));


Console.WriteLine("Execution Complete");