public class BoilAction : Action
{
    public int Temperature { get; }
    public int DurationMinutes { get; }
    
    public BoilAction(Ingredient ingredient, int temperature, int durationMinutes) 
        : base("Вскипятить", ingredient)
    {
        Temperature = temperature;
        DurationMinutes = durationMinutes;
    }
    
    public override void Display(int i = 0)
    {
        string padding = new string(' ', i * 6);
        Console.WriteLine($"{padding}{Name} {TargetIngredient.Name}: {Temperature}°C, {DurationMinutes}мин");
    }
    public override void Execute()
    {
        Console.WriteLine($"{Name} {TargetIngredient.Name} до {Temperature}°C за {DurationMinutes}мин");
    }
}