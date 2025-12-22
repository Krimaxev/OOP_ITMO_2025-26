using Lab_3.Models;
using Lab_3.Patterns.Visitor;
using Xunit;

namespace Lab_3.Tests;

public class VisitorTests
{
    [Fact]
    public void TotalCostVisitor_ShouldCalculateBasicTotal()
    {
        Order order = new Order();
        order.Products.Add(new OrderProduct 
        { 
            Meal = new Meal { Price = 450 }, 
            NumProducts = 2 
        });
        order.Products.Add(new OrderProduct 
        { 
            Meal = new Meal { Price = 100 }, 
            NumProducts = 3 
        });
        
        IOrderVisitor visitor = new TotalCostVisitor();
        decimal total = visitor.Visit(order);
        
        Assert.Equal(1200, total);
    }
    
    [Fact]
    public void TaxVisitor_ShouldCalculateTotalWithTax()
    {
        Order order = new Order();
        order.Products.Add(new OrderProduct 
        { 
            Meal = new Meal { Price = 1000 }, 
            NumProducts = 1 
        });
        
        IOrderVisitor visitor = new TaxVisitor(0.10m);
        decimal total = visitor.Visit(order);
        
        Assert.Equal(1100, total);
    }
    
    [Fact]
    public void DiscountVisitor_ShouldCalculateTotalWithDiscount()
    {
        Order order = new Order();
        order.Products.Add(new OrderProduct 
        { 
            Meal = new Meal { Price = 1000 }, 
            NumProducts = 1 
        });
        
        IOrderVisitor visitor = new DiscountVisitor(0.20m);
        decimal total = visitor.Visit(order);
        
        Assert.Equal(800, total);
    }
    
    [Fact]
    public void DeliveryFeeVisitor_ShouldAddDeliveryFee()
    {
        Order order = new Order();
        order.Products.Add(new OrderProduct 
        { 
            Meal = new Meal { Price = 500 }, 
            NumProducts = 2 
        });
        
        IOrderVisitor visitor = new DeliveryFeeVisitor(200);
        decimal total = visitor.Visit(order);
        
        Assert.Equal(1200, total);
    }
    
    [Fact]
    public void TotalCostVisitor_ShouldReturnZero_ForEmptyOrder()
    {
        Order order = new Order();
        
        IOrderVisitor visitor = new TotalCostVisitor();
        decimal total = visitor.Visit(order);
        
        Assert.Equal(0, total);
    }
}