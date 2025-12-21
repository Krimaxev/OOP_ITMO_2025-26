namespace VendingApp;

/// Базовый абстрактный класс, он хранит общие поля Code и Name, которые разделяют
/// все потомки (продукты, монеты и так далее).
public  class Item
{
    public string Code { get; set;}
    public string Name { get; set;}
}