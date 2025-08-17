using System.ComponentModel.Design;

class Program()
{
    public static void Main(string[] args)
    {
        // Salary salary = new Salary();
        // string path = "salary.txt";
        // string input = File.ReadAllText(path);
        // salary.SalaryInfo(input);

        var brands = new List<Brand>()
        {
            new Brand{Id = 1, Name = "Cong ty A"},
            new Brand{Id = 2, Name = "Cong ty B"}
        };
        List<Product> products = new List<Product>()
        {
            new Product(1, "Ao dai", new[] { "vang", "do" }, 20, 1),
            new Product(2, "Ao khoac day", new[] { "trang", "den", "cam" }, 32, 2),
            new Product(3, "Ao khoac mong", new[] { "trang", "den" }, 30, 2),
            new Product(4, "Ao thun", new[] { "xanh", "trang" }, 15, 1),
            new Product(5, "Quan jean", new[] { "xanh den", "den" }, 25, 3),
            new Product(6, "Dam cong so", new[] { "do", "tim" }, 40, 1),
            new Product(7, "Chan vay dai", new[] { "den", "trang" }, 22, 1),
            new Product(8, "Ao so mi", new[] { "xanh", "trang", "kem" }, 18, 2),
            new Product(9, "Ao len", new[] { "nau", "vang" }, 28, 2),
            new Product(10, "Quan short", new[] { "do", "den" }, 14, 3)
        };

        Console.WriteLine("Danh sach san pham truoc tuy van:");
        foreach (var item in products)
        {
            Console.WriteLine(item.ToString());
        }

        Console.WriteLine("Danh sach san pham sau truy van:");

        // in ra ten san pham, ten thuong hieu, gia (10 - 23), gia giam dan
        products.Where(p => p.Price >= 10 && p.Price <= 23)
                .OrderByDescending(p => p.Price)
                .Join(brands, p => p.Brand, b => b.Id, (product, brand) =>
                {
                    return new
                    {
                        TenSP = product.Name,
                        TenTH = brand.Name,
                        Gia = product.Price
                    };
                })
                .ToList()
                .ForEach(i => Console.WriteLine($"{i.TenSP} {i.TenTH} {i.Gia}"));
                
        var query = from p in products
                    join b in brands on p.Brand equals b.Id
                    where p.Price >= 10 && p.Price <= 23
                    orderby p.Price descending
                    select new
                    {
                        ten = p.Name,
                        th = b.Name,
                        gia = p.Price
                    };
        query.ToList().ForEach(i => Console.WriteLine(i));
                    
    }
}

