namespace Lab_3.Models;
using Lab_3.Patterns.State;

public class Order
{
    public int ID { get; set; }
    public decimal Cost { get; set; }
    public string Address { get; set; } 
    public Meal Meal { get; set; }
    public int NumProducts { get; set; }
    public IOrderDelivery Stage { get; set; }
    
    public List<Order> Products =  new List<Order>();
    
    public Order()
    {
        Stage = new Order_Complect(); 
    }
    
    public void MoveToNextStage()
    {
        Stage.NextState(this);
    }
    
}