using System;

namespace VendingApp;


/// Вся логика автомата: хранит ассортимент, банк монет и рабочий цикл.
public class VendingMachine
{
    private readonly Dictionary <string, Food> _products = new();
    private readonly Dictionary <decimal,int> _bank = new()
    {
        {10,10}, {5,10}, {2,20}, {1,50}
    };

    private decimal _balance;
    private const string _adminPin = "071025";

    public VendingMachine()
    {
        AddProduct(new Food("11","Lipton", 80,10));
        AddProduct(new Food("12","Вода питьевая", 40,10));
        AddProduct(new Food("13","Яблочный сок", 60,10));
        AddProduct(new Food("14","Тульский пряник", 70,10));
        AddProduct(new Food("21","Батончик Snickers", 90,10));
        AddProduct(new Food("22","Батончик Twix",     85,10));
        AddProduct(new Food("23","Квас",              80,10));
        AddProduct(new Food("24","Козинак",           90,10));
        AddProduct(new Food("31","Халва",                     65,10));
        AddProduct(new Food("32","Choco pie",                 70,10));
        AddProduct(new Food("33","Вода газированная",         45,10));
        AddProduct(new Food("34","Апельсиновый сок",          65,10));
        AddProduct(new Food("41","Вафли",            75,10));
        AddProduct(new Food("42","Барни",            60,10));
        AddProduct(new Food("43","Печенье брауни",   85,10));
        AddProduct(new Food("44","Боржоми",          50,10));
    }

    private void AddProduct(Food p) => _products[p.Code] = p;

    public void Run()
    {
        while (true)
        {
            Console.Clear();
            ShowProducts();
            Console.WriteLine($"\nБаланс: {_balance} руб.");
            Console.WriteLine("1) Вставить монету  2) Выбрать товар  3) Отмена  4) Администратор  5) Выход");

            switch (Console.ReadLine())
            {
                case "1": InsertCoin();    break;
                case "2": SelectProduct(); break;
                case "3": Cancel();        break;
                case "4": Admin();         break;
                case "5": return;
            }

            Console.WriteLine("Продолжить");
            Console.ReadLine();
        }
    }

    //действия пользователя
    private void InsertCoin()
    {
        Console.Write("Номинал (1,2,5,10): ");
        if (!decimal.TryParse(Console.ReadLine(), out var nom) || !_bank.ContainsKey(nom))
        {
            Console.WriteLine("Такую монету автомат не принимает.");
            return;
        }

        _bank[nom]++;
        _balance += nom;
        Console.WriteLine($"Принято {nom} руб. Баланс {_balance}");
    }

    
    private void SelectProduct()
    {
        Console.Write("Код товара: ");
        var code = Console.ReadLine()?.ToUpper();

        if (!_products.TryGetValue(code!, out var p))
        {
            Console.WriteLine("Нет такого товара.");
            return;
        }
        if (p.Quantity == 0)
        {
            Console.WriteLine("Товар закончился.");
            return;
        }
        if (_balance < p.Price)
        {
            Console.WriteLine($"Нужно ещё {p.Price - _balance} руб.");
            return;
        }

        p.Dispense();
        _balance -= p.Price;
        Console.WriteLine($"Заберите {p.Name}!");
        GiveChange();
    }

    private void Cancel()
    {
        Console.WriteLine("Операция отменена.");
        GiveChange();
    }

    //выдача сдачи
    private void GiveChange()
    {
        if (_balance == 0) return;

        decimal change = _balance;
        Console.Write("Сдача: ");

        foreach (var nom in new decimal[] {10,5,2,1})
        {
            while (change >= nom && _bank[nom] > 0)
            {
                change -= nom;
                _bank[nom]--;
                Console.Write($"{nom} ");
            }
        }

        if (change > 0) Console.Write("Не вся сдача выдана");
        Console.WriteLine();
        _balance = 0;
    }

    // вывод ассортимента
    private void ShowProducts()
    {
        Console.WriteLine("КОД  |  ТОВАР  | ЦЕНА | КОЛИЧЕСТВО");
        foreach (var p in _products.Values)
            Console.WriteLine($"{p.Code,-3} | {p.Name,-25} | {p.Price,4} | {p.Quantity,3}");
    }

    //администраторский режим
    private void Admin()
    {
        Console.Write("PIN: ");
        if (Console.ReadLine() != _adminPin)
        {
            Console.WriteLine("Неверный PIN.");
            return;
        }

        while (true)
        {
            Console.WriteLine("\n1) Пополнить товар  2) Инкассация  0) Выход");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.Write("Код и количество (11 10): ");
                    var parts = Console.ReadLine()?.Split(' ');
                    if (parts?.Length == 2 && _products.TryGetValue(parts[0], out var prod) && int.TryParse(parts[1], out var qty))
                        prod.Refill(qty);
                    else
                        Console.WriteLine("Ошибка ввода.");
                    break;

                case "2":
                    decimal total = 0;
                    foreach (var pair in _bank)
                    { total += pair.Key * pair.Value; _bank[pair.Key] = 0; }
                    Console.WriteLine($"Собрано {total} руб.");
                    break;

                case "0": return;
            }
        }
    }
}