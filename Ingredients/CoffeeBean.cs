public class CoffeeBean : Ingredient
{
    public string RoastLevel { get; set; }
    public CoffeeBean(decimal NetWeight, string roastlevel = "Средняя") : base("Кофейные зёрна", NetWeight)
    {
        RoastLevel = roastlevel;
    }
    public override string Name => "Кофейные зёрна";
}