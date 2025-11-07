using ShopManager.Domain;

namespace ShopManager.Services;

public interface IShopService
{
    void AddProduct(Product product);
    void AddCustomer(Customer customer);
    void CreateOrder(int customerId, List<int> productIds);
    void ShowAllProduct();
    void ShowAvailableProduct();
    void ShowAllOrders();
}
