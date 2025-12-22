using Lab_3.Models;

namespace Lab_3.Patterns.Command;


public interface ICommand
{
    public void Complete();
}

public class AddMealCommand : ICommand
{
    private Order order;
    private Meal meal;
    private int quantity;
    
    public AddMealCommand(Order order, Meal meal, int quantity)
    {
        this.order = order;
        this.meal = meal;
        this.quantity = quantity;
    }
    
    public void Complete()
    {
        Order product = null;
        foreach (var p in order.Products)
        {
            if (p.Meal == meal)
            {
                product = p;
                break;
            }
        }
        
        if (product != null)
        {
            product.NumProducts += quantity;
        }
        else
        {
            order.Products.Add(new Order 
            { 
                Meal = meal, 
                NumProducts = quantity 
            });
        }
    }
}


public class RemoveMeal : ICommand
{
    private Order order;
    private Meal meal;
    
    public RemoveMeal(Order order, Meal meal)
    {
        this.order = order;
        this.meal = meal;
    }
    
    public void Complete()
    {
        Order product = null;
        foreach (var p in order.Products)
        {
            if (p.Meal == meal)
            {
                product = p;
                break;
            }
        }
        if (product != null)
        {
            order.Products.Remove(product);
        }
    }
}


public class ClearOrder : ICommand
{
    private Order order;
    
    public ClearOrder(Order order)
    {
        this.order = order;
    }
    
    public void Complete()
    {
        order.Products.Clear();
    }
}