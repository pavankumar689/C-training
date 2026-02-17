 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

#region Models

public class Order
{
    public int OrderId { get; set; }
    public string CustomerName { get; set; }
    public List<string> Items { get; set; } = new();
    public decimal TotalAmount { get; set; }
    public OrderStatus Status { get; set; }
}

public enum OrderStatus
{
    Pending,
    PaymentProcessing,
    Cooking,
    ReadyForDelivery,
    OutForDelivery,
    Delivered,
    Failed
}


public class PaymentResult
{
    public bool IsSuccessful { get; set; }
    public string TransactionId { get; set; }
    public string ErrorMessage { get; set; }
}

#endregion

#region Services

public class PaymentGateway
{
    public async Task<PaymentResult> ProcessPaymentAsync(decimal amount)
    {
        await Task.Delay(2000);

        var random = new Random();
        bool success = random.Next(0, 10) > 1;

        return new PaymentResult
        {
            IsSuccessful = success,
            TransactionId = success ? Guid.NewGuid().ToString() : null,
            ErrorMessage = success ? null : "Payment Declined"
        };
    }
}

public class KitchenStation
{
    public async Task PrepareItemAsync(string item)
    {
        var random = new Random();
        int time = random.Next(1000, 5000);

        await Task.Delay(time);

        Console.WriteLine($"{item} prepared in {time}ms");
    }
}

public class DeliveryService
{
    public async Task DeliverOrderAsync(Order order)
    {
        Console.WriteLine($"Delivery partner assigned for Order {order.OrderId}");

        await Task.Delay(3000);

        Console.WriteLine($"Order {order.OrderId} delivered successfully!");
    }
}

public class NotificationService
{
    public async Task SendNotificationAsync(string name, string message)
    {
        await Task.Delay(500);
        Console.WriteLine($"Notification to {name}: {message}");
    }
}

#endregion

#region Processor

public class OrderProcessor
{
    private readonly PaymentGateway _paymentGateway = new();
    private readonly KitchenStation _kitchenStation = new();
    private readonly DeliveryService _deliveryService = new();
    private readonly NotificationService _notificationService = new();

    public event Func<Order, Task> OrderStatusChanged;

    private async Task UpdateStatusAsync(Order order, OrderStatus status)
    {
        order.Status = status;
        if (OrderStatusChanged != null)
            await OrderStatusChanged(order);
    }

    public async Task<Order> ProcessOrderAsync(Order order)
    {
        try
        {
            Console.WriteLine($"\nProcessing Order {order.OrderId}");

            await UpdateStatusAsync(order, OrderStatus.PaymentProcessing);

            await _notificationService.SendNotificationAsync(
                order.CustomerName,
                "Processing your payment..."
            );

            var paymentTask = _paymentGateway.ProcessPaymentAsync(order.TotalAmount);
            var timeoutTask = Task.Delay(10000);

            var completed = await Task.WhenAny(paymentTask, timeoutTask);

            if (completed == timeoutTask)
                throw new TimeoutException("Payment Timeout");

            var paymentResult = await paymentTask;

            if (!paymentResult.IsSuccessful)
                throw new Exception(paymentResult.ErrorMessage);

            await UpdateStatusAsync(order, OrderStatus.Cooking);

            var cookingTasks = order.Items
                .Select(item => _kitchenStation.PrepareItemAsync(item))
                .ToList();

            await Task.WhenAll(cookingTasks);

            await UpdateStatusAsync(order, OrderStatus.ReadyForDelivery);

            await UpdateStatusAsync(order, OrderStatus.OutForDelivery);

            await _deliveryService.DeliverOrderAsync(order);

            await UpdateStatusAsync(order, OrderStatus.Delivered);

            await _notificationService.SendNotificationAsync(
                order.CustomerName,
                "Order Delivered!"
            );

            return order;
        }
        catch (Exception ex)
        {
            await UpdateStatusAsync(order, OrderStatus.Failed);

            await _notificationService.SendNotificationAsync(
                order.CustomerName,
                $"Order Failed: {ex.Message}"
            );

            return order;
        }
    }

    public async Task<List<Order>> ProcessBulkOrdersAsync(
        List<Order> orders,
        int maxConcurrency = 3)
    {
        using var semaphore = new SemaphoreSlim(maxConcurrency);

        var tasks = orders.Select(async order =>
        {
            await semaphore.WaitAsync();
            try
            {
                return await ProcessOrderAsync(order);
            }
            finally
            {
                semaphore.Release();
            }
        });

        return (await Task.WhenAll(tasks)).ToList();
    }
}

#endregion

#region Program

class Program
{
    static async Task Main()
    {
        var processor = new OrderProcessor();

        processor.OrderStatusChanged += async (order) =>
        {
            Console.WriteLine($"Order {order.OrderId} Status -> {order.Status}");
            await Task.CompletedTask;
        };

        var orders = new List<Order>
        {
            new() {
                OrderId = 1,
                CustomerName = "John",
                Items = new List<string>{ "Burger","Fries" },
                TotalAmount = 20,
                Status = OrderStatus.Pending
            },
            new() {
                OrderId = 2,
                CustomerName = "Alice",
                Items = new List<string>{ "Pizza" },
                TotalAmount = 15,
                Status = OrderStatus.Pending
            },
            new() {
                OrderId = 3,
                CustomerName = "Bob",
                Items = new List<string>{ "Pasta","Soup" },
                TotalAmount = 25,
                Status = OrderStatus.Pending
            }
        };

        var results = await processor.ProcessBulkOrdersAsync(orders, 2);

        Console.WriteLine("\nFinal Summary:");
        foreach (var order in results)
            Console.WriteLine($"Order {order.OrderId} Final Status: {order.Status}");
    }
}

#endregion
