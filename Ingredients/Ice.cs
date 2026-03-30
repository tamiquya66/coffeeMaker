public class Ice : Ingredient
{
    public Ice(decimal NetWeight) : base("Лёд", NetWeight)
    {
    }
    public void AddMessage(int i = 0)
    {
        string padding = new string(' ', i * 2);
        Console.WriteLine($"\n{padding} {Name}: {NetWeight}г");
    }
    public override void Display(int i = 0)
    {
        string padding = new string(' ', i * 2);
        Console.WriteLine($"{padding}Добавить Лёд: {NetWeight}г");
    }
    public override void Execute()
    {
    }
}