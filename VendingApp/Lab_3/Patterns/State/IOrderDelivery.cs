using Lab_3.Models;

namespace Lab_3.Patterns.State;

public interface IOrderDelivery
{ 
    void NextState(Order order);
}
public class Order_Complect : IOrderDelivery
{
    public void NextState(Order order)
    {
        order.Stage = new Order_Transport();
    }
}

public class Order_Transport : IOrderDelivery
{
    public void NextState(Order order)
    {
        order.Stage = new Order_Complete();
    }
}

public class Order_Complete : IOrderDelivery
{
    public void NextState(Order order)
    {
        throw new InvalidOperationException("Ваш заказ доставлен!");
    }
}