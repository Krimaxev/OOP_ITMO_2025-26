using Lab_3.Models;
using Lab_3.Patterns.Composite;
using Xunit;

namespace Lab_3.Tests;

public class CompositeTests
{
    [Fact]
    public void MenuMeal_ShouldDisplayMealInfo()
    {
        Meal pizza = new Meal { Name = "Пицца", Price = 450 };
        MenuMeal menuItem = new MenuMeal(pizza);
        
        // Проверяем что объект создан
        Assert.NotNull(menuItem);
        Assert.Equal(pizza, menuItem.Meal);
    }
    
    [Fact]
    public void Menu_ShouldAddMenuItem()
    {
        Menu menu = new Menu("Главное меню");
        Meal pizza = new Meal { Name = "Пицца", Price = 450 };
        MenuMeal item = new MenuMeal(pizza);
        
        menu.Add(item);
        
        Assert.Equal(1, menu.products.Count);
    }
    
    [Fact]
    public void Menu_ShouldAddMultipleItems()
    {
        Menu menu = new Menu("Главное меню");
        Meal pizza = new Meal { Name = "Пицца", Price = 450 };
        Meal cola = new Meal { Name = "Кола", Price = 100 };
        
        menu.Add(new MenuMeal(pizza));
        menu.Add(new MenuMeal(cola));
        
        Assert.Equal(2, menu.products.Count);
    }
    
    [Fact]
    public void Menu_ShouldRemoveMenuItem()
    {
        Menu menu = new Menu("Главное меню");
        Meal pizza = new Meal { Name = "Пицца", Price = 450 };
        MenuMeal item = new MenuMeal(pizza);
        
        menu.Add(item);
        menu.Remove(item);
        
        Assert.Empty(menu.products);
    }
    
    [Fact]
    public void Menu_ShouldAddSubMenu()
    {
        Menu mainMenu = new Menu("Главное меню");
        Menu subMenu = new Menu("Горячие блюда");
        Meal pizza = new Meal { Name = "Пицца", Price = 450 };
        
        subMenu.Add(new MenuMeal(pizza));
        mainMenu.Add(subMenu);
        
        Assert.Equal(1, mainMenu.products.Count);
        Assert.Equal(1, subMenu.products.Count);
    }
}