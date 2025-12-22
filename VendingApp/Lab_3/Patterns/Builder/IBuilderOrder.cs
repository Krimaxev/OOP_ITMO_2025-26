using Lab_3.Models;

namespace Lab_3.Patterns.Builder;

public interface IBuilderOrder
{
    void SetAddress (string address);
    Order GetOrder();
    
}


public class OrderBuilder : IBuilderOrder
{
    private Order order;

    public OrderBuilder()
    {
        order = new Order();
    }
    
    public void SetAddress(string address)
    {
        order.Address = address;
    }

    
    public void AddMeal(Meal meal, int quantity)
    {
        bool found = false;
    
        foreach (var p in order.Products)
        {
            if (p.Meal == meal)
            {
                p.NumProducts += quantity;
                found = true;
                break;
            }
        }
    
        if (found == false)
        {
            OrderProduct newProduct = new OrderProduct();
            newProduct.Meal = meal;
            newProduct.NumProducts = quantity;
            order.Products.Add(newProduct);
        }
    }

    public Order GetOrder()
    {
        return order;
    }
}