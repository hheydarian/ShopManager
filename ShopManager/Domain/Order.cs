namespace ShopManager.Domain;

public class Order
{
    public int Id { get; set; }
    public Customer Customer { get; set; }
    public List<Product> Products { get; set; }
    public decimal TotalPrice => Products.Sum(x => x.Price);

    public Order(int id, Customer customer)
    {
        Id = id;
        Customer = customer;
    }
    public void AddProduct(Product p)
    {
        Products.Add(p);
    }
}
