public class Water : Ingredient
{
    public Water(decimal NetWeight) : base("Вода", NetWeight)
    {
    }
    public override void AddMessage(int i = 0)
    {
        string padding = new string(' ', i * 2);
        Console.WriteLine($"\n{padding} {Name}: {NetWeight}мл");
    }
    public override void Display(int i = 0)
    {
    }
    public override void Execute()
    {
    }
}