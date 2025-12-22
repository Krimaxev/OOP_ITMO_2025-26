using Lab_3.Models;
using Lab_3.Patterns.Command;
using Xunit;

namespace Lab_3.Tests;

public class CommandTests
{
    [Fact]
    public void AddMealCommand_ShouldAddNewMeal()
    {
        Order order = new Order();
        Meal pizza = new Meal { Name = "Пицца", Price = 450 };
        ICommand command = new AddMealCommand(order, pizza, 2);
        
        command.Complete();
        
        Assert.Equal(1, order.Products.Count);
        Assert.Equal(2, order.Products[0].NumProducts);
    }
    
    [Fact]
    public void AddMealCommand_ShouldIncreaseQuantity_WhenMealExists()
    {
        Order order = new Order();
        Meal pizza = new Meal { Name = "Пицца", Price = 450 };
        
        ICommand command1 = new AddMealCommand(order, pizza, 2);
        command1.Complete();
        
        ICommand command2 = new AddMealCommand(order, pizza, 3);
        command2.Complete();
        
        Assert.Equal(1, order.Products.Count);
        Assert.Equal(5, order.Products[0].NumProducts);
    }
    
    [Fact]
    public void RemoveMeal_ShouldRemoveMealFromOrder()
    {
        Order order = new Order();
        Meal pizza = new Meal { Name = "Пицца", Price = 450 };
        order.Products.Add(new OrderProduct { Meal = pizza, NumProducts = 2 });
        
        ICommand command = new RemoveMeal(order, pizza);
        command.Complete();
        
        Assert.Empty(order.Products);
    }
    
    [Fact]
    public void ClearOrder_ShouldRemoveAllProducts()
    {
        Order order = new Order();
        order.Products.Add(new OrderProduct { Meal = new Meal(), NumProducts = 2 });
        order.Products.Add(new OrderProduct { Meal = new Meal(), NumProducts = 1 });
        
        ICommand command = new ClearOrder(order);
        command.Complete();
        
        Assert.Empty(order.Products);
    }
}