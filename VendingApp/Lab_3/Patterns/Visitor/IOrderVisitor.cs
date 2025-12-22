using Lab_3.Models;
namespace Lab_3.Patterns.Visitor;

public interface IOrderVisitor
{
    decimal Visit(Order order);
}


public class TotalCostVisitor : IOrderVisitor
{
    public decimal Visit(Order order)
    {
        decimal total = 0;
        foreach (var p in order.Products)
        {
            total += p.Meal.Price * p.NumProducts;
        }
        return total;
    }
}


public class TaxVisitor : IOrderVisitor
{
    private decimal taxRate;
    public TaxVisitor(decimal taxRate)
    {
        this.taxRate = taxRate;
    }
    
    public decimal Visit(Order order)
    {
        decimal total = 0;
        foreach (var p in order.Products)
        {
            total += p.Meal.Price * p.NumProducts;
        }
        
        return total * (1 + taxRate);
    }
}


public class DiscountVisitor : IOrderVisitor
{
    private decimal discountPercent;
    public DiscountVisitor(decimal discountPercent)
    {
        this.discountPercent = discountPercent;
    }
    
    public decimal Visit(Order order)
    {
        decimal total = 0;
        foreach (var p in order.Products)
        {
            total += p.Meal.Price * p.NumProducts;
        }
        
        return total * (1 - discountPercent);
    }
}


public class DeliveryFeeVisitor : IOrderVisitor
{
    private decimal deliveryFee;
    
    public DeliveryFeeVisitor(decimal deliveryFee)
    {
        this.deliveryFee = deliveryFee;
    }
    
    public decimal Visit(Order order)
    {
        decimal total = 0;
        foreach (var p in order.Products)
        {
            total += p.Meal.Price * p.NumProducts;
        }
        
        return total + deliveryFee;
    }
}