using Lab_3.Models;
using Lab_3.Patterns.Builder;
using Xunit;

namespace Lab_3.Tests;

public class OrderBuilderTests
{
    [Fact]
    public void SetAddress_ShouldSetOrderAddress()
    {
        OrderBuilder builder = new OrderBuilder();
        builder.SetAddress("ул. Ленина, 10");
        Order order = builder.GetOrder();
        
        Assert.Equal("ул. Ленина, 10", order.Address);
    }
    
    [Fact]
    public void AddMeal_ShouldAddNewMealToOrder()
    {
        OrderBuilder builder = new OrderBuilder();
        Meal pizza = new Meal { Name = "Пицца", Price = 450 };
        
        builder.AddMeal(pizza, 2);
        Order order = builder.GetOrder();
        
        Assert.Equal(1, order.Products.Count);
        Assert.Equal(2, order.Products[0].NumProducts);
    }
    
    [Fact]
    public void AddMeal_ShouldIncreaseQuantity_WhenMealAlreadyExists()
    {
        OrderBuilder builder = new OrderBuilder();
        Meal pizza = new Meal { Name = "Пицца", Price = 450 };
        
        builder.AddMeal(pizza, 2);
        builder.AddMeal(pizza, 3);
        Order order = builder.GetOrder();
        
        Assert.Equal(5, order.Products[0].NumProducts);
    }
}