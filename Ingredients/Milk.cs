public class Milk : Ingredient
{
    public string FatLevel { get; set; }
    public Milk(decimal NetWeight, string fatlevel = "3.2%") : base("Молоко", NetWeight)
    {
        FatLevel = fatlevel;
    }
        public override void AddMessage()
    {
        Console.WriteLine($"✓ Добавлен ингредиент: Молоко ({FatLevel}): {NetWeight}мл");
    }
    public override void Display(int i = 0)
    {
        string padding = new string(' ', i * 2);
        Console.WriteLine($"{padding}Добавить Молоко ({FatLevel}): {NetWeight}мл");
    }
    public override void Execute()
    {
    }
    public override void GetParametersFromUser()
    {
        Console.Clear();
        Console.WriteLine("Выберите процент жира (по умолчанию: 3.2%):");
        Console.WriteLine("1. 1.6%");
        Console.WriteLine("2. 3.2%");
        Console.WriteLine("3. 6.0%");
        Console.Write("Ваш выбор (1-3): ");
        
        string? choice = Console.ReadLine();
        FatLevel = choice switch
        {
            "1" => "1.6%",
            "2" => "3.2%",
            "3" => "6.0%",
            _ => "3.2%"
        };
    }
}