public class Syrup : Ingredient
{
    public string Flavor { get; set; }
    public Syrup(decimal NetWeight, string flavor = "Ваниль") : base("Сироп", NetWeight)
    {
        Flavor = flavor;
    }
    public override void AddMessage(int i = 0)
    {
        string padding = new string(' ', i * 2);
        Console.WriteLine($"\n{padding} {Name}: {NetWeight}мл, Вкус: {Flavor}");
    }
    public override void Display(int i = 0)
    {
    }
    public override void Execute()
    {
    }
    public override void GetParametersFromUser()
    {
        Console.Write("Введите вкус сиропа (Ваниль, Карамель, Фундук и т.д.): ");
        string? flavor = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(flavor))
        {
            Flavor = flavor;
        }
    }
}