namespace ShopManager.Domain;

public class Product
{
    private string _name
    {
        get => _name;
        set => _name = value ?? throw new ArgumentNullException(nameof(value), "Name cannot empty.");
    }
    private decimal _price
    {
        get => _price;
        set
        {
            if (value < 0 || value > 1_000_000_000m)
            {
                throw new ArgumentOutOfRangeException(nameof(value),"Value price cannot < 0 or > 1b");
            }
            _price = value;
        }
    }
    private int _stock
    {
        get => _stock;
        set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Value cannot < 0 or > 100");
            }
        }
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }

    public int Stock { get; set; }

    public void PrintInfo()
    {
        Console.WriteLine($"Product Info =>  ID: {Id} - Name: {Name} - Price: {Price} - Stock: {Stock}");
    }

    public Product(int id, string name, decimal price, int stock)
    {
        Id = id;
        Name = name;
        Price = price;
        Stock = stock;
    }

    public bool InStock => Stock > 0;
}
