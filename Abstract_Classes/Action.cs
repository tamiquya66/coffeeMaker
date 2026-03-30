using DrinkApp;
public abstract class Action : Element
{
    public virtual string Name { get; set; }
    public Ingredient? TargetIngredient { get; protected set; }
    protected List<Element> _elements = new List<Element>();
    protected Action(string name, Ingredient? ingredient = null)
    {
        Name = name;
        TargetIngredient = ingredient;
    }
    public virtual void AddElement(Element element)
    {
        _elements.Add(element);
    }
    public abstract void Display(int i = 0);
    public abstract void Execute();
    public void AddMessage() // 1st thing that appears when user adding
    {
        Console.WriteLine($"Действие: {Name}");
    }
}
