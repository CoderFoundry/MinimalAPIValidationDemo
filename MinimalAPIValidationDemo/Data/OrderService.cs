using System.Text.Json;
using MinimalAPIValidationDemo.Models;

namespace MinimalAPIValidationDemo.Data;

public class OrderService
{
    private readonly List<Order> _orders = [];

    public OrderService()
    {
        var mockData = File.ReadAllText("Data/orders.json");
        _orders = JsonSerializer.Deserialize<List<Order>>(mockData, JsonSerializerOptions.Web) ?? [];
    }

    public List<Order> GetOrders(string? searchTerm = null)
    {
        return string.IsNullOrWhiteSpace(searchTerm)
            ? _orders
            : [.. _orders.Where(o => $"{o.CustomerName}".Contains(searchTerm, StringComparison.OrdinalIgnoreCase))];
    }

    public void AddOrder(OrderDTO order)
    {
        // Map OrderDTO to Order
        var newOrder = new Order
        {
            CustomerName = order.CustomerName,
            UnitPrice = order.UnitPrice,
            Quantity = order.Quantity,
            DeliveryDate = order.DeliveryDate
        };

        if (!_orders.Contains(newOrder))
        {
            _orders.Add(newOrder);
        }
    }

}
