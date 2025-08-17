// select, where, selectmany
// min, max, sum, average
// join, groupjoin, groupby
// take, skip
// orderby / orderbydescending
// reverse
// distinct
// single / singleordefault
// any, all
// count
/*
    cu phap truy van linq
    1) xac dinh nguon: from tensanpham in IEnumerables
       ... where, order by...
    2) lay du lieu: select, group by...
*/
class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string[] Colors { get; set; }
    public int Price { get; set; }
    public int Brand { get; set; }
    public Product(int id, string name, string[] colors, int price, int brand)
    {
        Id = id; Name = name; Colors = colors; Price = price; Brand = brand;
    }
    public override string ToString()
    {
        string colorsFormatted = $"[{String.Join(",", Colors)}]".PadRight(20);
        return $"{Id,-3} {Name,-20} {Price,-5} {colorsFormatted} {Brand}";
    }
}

class Brand
{
    public string? Name { get; set; }
    public int Id { get; set; }
}
