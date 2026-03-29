public class AddAction : Action
{
    private Ingredient _ingredient;
    public AddAction(Ingredient ingredient) : base("Добавление")
    {
        _ingredient = ingredient;
    }
    
    public override void Display(int i = 0)
    {
    }
    
    public override void Execute()
    {
        Console.WriteLine($"   Добавление {_ingredient.Name} ({_ingredient.NetWeight}г)");
        _ingredient.AddMessage();
    }
}