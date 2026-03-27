using DrinkApp;
public abstract class Ingredient : Element
{
    public virtual string Name { get; set; }
    public decimal NetWeight {get; protected set; }
    protected Ingredient(string name, decimal netWeight)
    {
        Name = name;
        NetWeight = netWeight;
    }
    public static Ingredient Create(IngredientType type, decimal weight)
    {
        switch (type)
        {
            case IngredientType.Water:
                return new Water(weight);
            case IngredientType.Syrup:
                return new Syrup(weight);
            case IngredientType.Coffee:
                return new CoffeeBean(weight);
            case IngredientType.Milk:
                return new Milk(weight);
            case IngredientType.Ice:
                return new Ice(weight);
            default:
                throw new ArgumentException("Неизвестный тип ингредиента");
        }
    }
    public void AddMessage()
    {
        Console.WriteLine($"Успешно добавлен ингредиент {Name} ({NetWeight})");
    }
}