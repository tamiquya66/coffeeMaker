public class BoilAction : Action
{
    public int Temperature { get; }
    public int DurationMin { get; }
    public BoilAction(int temperature, int duration) : base("Кипячение")
    {
        Temperature = temperature;
        DurationMin = duration;
    }
    public override void Display(int i = 0)
    {
    }
    public override void Execute()
    {
    }
}