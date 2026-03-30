public class WhiskAction : Action
{
    public int Speed { get; }
    public int DurationSeconds { get; }
    
    public WhiskAction(Ingredient ingredient, int speed, int durationSeconds) 
        : base("Взбить", ingredient)
    {
        Speed = speed;
        DurationSeconds = durationSeconds;
    }
   public override void Display(int i = 0)
    {
        string padding = new string(' ', i * 6);
        Console.WriteLine($"{padding}{Name} {TargetIngredient.Name}: скорость {Speed}, {DurationSeconds}сек");
    }
    public override void Execute()
    {
        Console.WriteLine($"{TargetIngredient.Name} взбито {DurationSeconds} сек на скорости {Speed}");
    }
}