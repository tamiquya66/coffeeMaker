using DrinkApp;
public abstract class Action : Element
{
    public virtual string Name { get; set; }
    List<Element> _elements = new List<Element>();
    protected Action(string name)
    {
        Name = name;
    }
    public abstract void Display(int i = 0);
    public abstract void Execute();
    public void AddMessage(int i = 0) // 1st thing that appears when user adding
    {
        Console.WriteLine($"Действие: {Name}");
    }
}
