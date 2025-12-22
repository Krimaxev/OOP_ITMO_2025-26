using Lab_3.Models;
using Lab_3.Patterns.State;
using Xunit;

namespace Lab_3.Tests;

public class StateTests
{
    [Fact]
    public void Order_ShouldStartInComplectState()
    {
        Order order = new Order();
        
        Assert.IsType<Order_Complect>(order.Stage);
    }
    
    [Fact]
    public void Order_ShouldMoveFromComplectToTransport()
    {
        Order order = new Order();
        
        order.MoveToNextStage();
        
        Assert.IsType<Order_Transport>(order.Stage);
    }
    
    [Fact]
    public void Order_ShouldMoveFromTransportToComplete()
    {
        Order order = new Order();
        order.Stage = new Order_Transport();
        
        order.MoveToNextStage();
        
        Assert.IsType<Order_Complete>(order.Stage);
    }
    
    [Fact]
    public void Order_ShouldThrowException_WhenMovingFromCompleteState()
    {
        Order order = new Order();
        order.Stage = new Order_Complete();
        
        Assert.Throws<InvalidOperationException>(() => order.MoveToNextStage());
    }
    
    [Fact]
    public void Order_ShouldPassThroughAllStates()
    {
        Order order = new Order();
        
        Assert.IsType<Order_Complect>(order.Stage);
        
        order.MoveToNextStage();
        Assert.IsType<Order_Transport>(order.Stage);
        
        order.MoveToNextStage();
        Assert.IsType<Order_Complete>(order.Stage);
    }
}