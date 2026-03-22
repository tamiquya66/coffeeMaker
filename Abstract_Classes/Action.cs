public abstract class Action : Element
{
    public virtual string Name { get; set; }
    List<Element> _elements = new List<Element>();
    protected Action(string name)
    {
        Name = name;
    }
    public abstract void Execute();
    public void AddMessage()
    {
        Console.WriteLine($"Успешно добавлено действие {Name}");
    }
}
