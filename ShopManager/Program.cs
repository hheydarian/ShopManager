using ShopManager.Domain;
using ShopManager.Services;

public class Program
{
    static void Main()
    {
        IShopService shop = new ShopService();

        shop.AddProduct(new Product(1, "Laptop", 1200, 5));
        shop.AddProduct(new Product(2, "Mouse", 25, 10));
        shop.AddProduct(new Product(3, "Keyboard", 45, 6));
        shop.AddCustomer(new Customer(1, "Hamed"));
        shop.AddCustomer(new Customer(2, "Sara"));

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== SHOP MANAGER ===");
            Console.WriteLine("1) Show All Products");
            Console.WriteLine("2) Show Available Products");
            Console.WriteLine("3) Create Order");
            Console.WriteLine("4) Show All Orders");
            Console.WriteLine("0) Exit");
            Console.Write("Select: ");
            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    shop.ShowAllProduct();
                    break;
                case "2":
                    shop.ShowAvailableProduct();
                    break;
                case "3":
                    Console.Write("Enter Customer ID: ");
                    int cId = int.Parse(Console.ReadLine() ?? "0");
                    Console.Write("Enter Product IDs (comma separated): ");
                    var ids = Console.ReadLine()!.Split(',').Select(int.Parse).ToList();
                    shop.CreateOrder(cId, ids);
                    break;
                case "4":
                    shop.ShowAllOrders();
                    break;
                case "0":
                    return;
            }

            Console.WriteLine("\nPress any key...");
            Console.ReadKey();
        }
    }
}