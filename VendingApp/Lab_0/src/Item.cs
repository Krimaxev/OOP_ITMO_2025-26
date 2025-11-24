namespace VendingApp;

/// Базовый абстрактный класс, он хранит общие поля Code и Name, которые разделяют
/// все потомки (продукты, монеты и так далее).
public  class Item
{
    public string Code { get; protected set;}
    public string Name { get; protected set;}
}