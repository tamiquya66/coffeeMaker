public class GrindAction : Action
{
    public string GrindSize { get; }
    
    public GrindAction(Ingredient ingredient, string grindSize) 
        : base("Перемолоть", ingredient)
    {
        GrindSize = grindSize;
    }
    public override void Display(int i = 0)
{
    string padding = new string(' ', i * 6);
    Console.WriteLine($"{padding}{Name} {TargetIngredient.Name}: {GrindSize} помол");
}
    public override void Execute()
    {
        Console.WriteLine($"{TargetIngredient.Name} перемолот до {GrindSize} помола");
    }
}