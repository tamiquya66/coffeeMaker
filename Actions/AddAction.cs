public class AddAction : Action
{
    private Ingredient _ingredient;
    public AddAction(Ingredient ingredient) : base("Добавление", ingredient)
    {
        _ingredient = ingredient;
    }
    public void AddElement(Element element)
    {
        _elements.Add(element);
    }
    public override void Display(int i = 0)
    {
        string padding = new string(' ', i * 2);
        Console.Write($"{padding}");
        _ingredient.Display(i);
        
        foreach (var element in _elements)
        {
            element.Display(i + 1);
        }
    }
    public override void Execute()
    {
        Console.WriteLine($"  Добавление {_ingredient.Name} ({_ingredient.NetWeight}г)");
        _ingredient.AddMessage();
        
        foreach (var element in _elements)
        {
            element.Execute();
        }
    }
}