using ShopManager.Domain;

namespace ShopManager.Services;

public class ShopService : IShopService
{
    private readonly List<Product> _products = new();
    private readonly List<Customer> _customers = new();
    private readonly List<Order> _orders = new();

    public void AddCustomer(Customer customer) => _customers.Add(customer);

    public void AddProduct(Product product) => _products.Add(product);

    public void CreateOrder(int customerId, List<int> productIds)
    {
        var customer = _customers.FirstOrDefault(c => c.Id == customerId);
        if (customer == null)
        {
            Console.WriteLine("Customer not found!");
            return;
        }
        var order = new Order(_orders.Count + 1, customer);
        foreach (var Id in productIds)
        {
            var p = _products.FirstOrDefault(x => x.Id == Id && x.InStock);
            if (p != null)
            {
                order.AddProduct(p);
                p.Stock--;
            }
        }
        _orders.Add(order);
        Console.WriteLine($" Order #{order.Id} created for {customer.Name}, Total: ${order.TotalPrice}");
    }

    public void ShowAllProduct()
    {
        foreach (var p in _products)
        {
            p.PrintInfo();
        }
    }

    public void ShowAvailableProduct()
    {
        var available = _products.Where(p => p.InStock).OrderBy(p => p.Price);
        foreach (var p in available)
        {
            p.PrintInfo();
        }
    }

    public void ShowAllOrders()
    {
        foreach (var o in _orders)
        {
            Console.WriteLine($"\nOrder #{o.Id} by {o.Customer.Name}");
            foreach (var p in o.Products)
                Console.WriteLine($"   - {p.Name} (${p.Price})");
            Console.WriteLine($"   Total: ${o.TotalPrice}");
        }
    }
}
