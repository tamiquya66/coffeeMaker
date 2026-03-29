public class CoffeeBean : Ingredient
{
    public string RoastLevel { get; set; }
    public CoffeeBean(decimal NetWeight, string roastlevel = "Средняя") : base("Кофейные зёрна", NetWeight)
    {
        RoastLevel = roastlevel;
    }
    public override void AddMessage(int i = 0)
    {
        string padding = new string(' ', i * 2);
        Console.WriteLine($"\n{padding} {Name} (Обжарка: {RoastLevel}): {NetWeight}г");
    }
    public override void Display(int i = 0)
    {
    }
    public override void Execute()
    {
    }
    public override void GetParametersFromUser()
    {
        Console.WriteLine("Выберите степень обжарки:");
        Console.WriteLine("1. Светлая");
        Console.WriteLine("2. Средняя");
        Console.WriteLine("3. Темная");
        Console.Write("Ваш выбор (1-3): ");
        
        string? choice = Console.ReadLine();
        RoastLevel = choice switch
        {
            "1" => "Светлая",
            "2" => "Средняя",
            "3" => "Темная",
            _ => "Средняя"
        };
    }
}