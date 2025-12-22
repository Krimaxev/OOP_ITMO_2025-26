using Lab_3.Models;

namespace Lab_3.Patterns.Composite;

public abstract class MenuProduct
{
    public abstract void SeeMenu();
    public virtual void Add(MenuProduct menuProduct) { }
    public virtual void Remove(MenuProduct menuProduct) { }
}

public class MenuMeal : MenuProduct
{
    public Meal Meal { get; set; }
    
    public MenuMeal(Meal meal)
    {
        Meal = meal;
    }
    public override void SeeMenu()
    {
        Console.WriteLine($"{Meal.Name} - {Meal.Price} руб.");
    }
}

public class Menu : MenuProduct
{ 
    public List<MenuProduct> products = new List<MenuProduct>();
    public string Name { get; set; }
    
    public Menu(string name)
    {
        Name = name;
    }
    
    public override void Add(MenuProduct menuProduct)
    {
        products.Add(menuProduct);
    }
    
    public override void Remove(MenuProduct menuProduct)
    {
        products.Remove(menuProduct);
    }

    public override void SeeMenu()
    {
        foreach (var product in products)
        {
            product.SeeMenu();  
        }
    }
}