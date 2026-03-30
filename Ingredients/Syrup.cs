public class Syrup : Ingredient
{
    public string Flavor { get; set; }
    public Syrup(decimal NetWeight, string flavor = "Ваниль") : base("Сироп", NetWeight)
    {
        Flavor = flavor;
    }
    public override void AddMessage()
    {
        Console.WriteLine($"✓ Добавлен ингредиент: Сироп ({Flavor}): {NetWeight}мл");
    }
    public override void Display(int i = 0)
    {
        string padding = new string(' ', i * 2);
        Console.WriteLine($"{padding}Добавить Сироп ({Flavor}): {NetWeight}мл");
    }
    public override void Execute()
    {
    }
    public override void GetParametersFromUser()
    {
        Console.Clear();
        Console.Write("Введите вкус сиропа (по умолчанию: Ваниль): ");
        string? flavor = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(flavor))
        {
            Flavor = flavor;
        }
    }
}