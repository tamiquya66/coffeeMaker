public class PourAction : Action
{
    public string To { get; }
    public PourAction(Ingredient ingredient, string to) : base("Переливание")
    {
        To = to;
    }
    public override void Display(int i = 0)
    {
        string padding = new string(' ', i * 6);
        Console.WriteLine($"{padding}{Name} {TargetIngredient.Name} → {To}");
    }
    public override void Execute()
    {
        Console.WriteLine($"{TargetIngredient.Name} пролита через {To}");
    }
}