namespace VendingApp;


/// Данный класс представляет монету определённого номинала.

public class Money: Item
{
    public decimal Value { get; }

    public Money(decimal value)
    {
            
        Value = value;
        Name = $"{Value}";
    }
}