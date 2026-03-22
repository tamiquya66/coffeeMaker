public abstract class Ingredient : Element
{
    public virtual string Name { get; set; }
    public decimal NetWeight {get; protected set; }
    protected Ingredient(string name, decimal netWeight)
    {
        Name = name;
        NetWeight = netWeight;
    }
    public void AddMessage()
    {
        Console.WriteLine($"Успешно добавлен ингредиент {Name} ({NetWeight})");
    }
}