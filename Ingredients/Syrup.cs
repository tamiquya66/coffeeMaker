public class Syrup : Ingredient
{
    public string Flavor { get; set; }
    public Syrup(decimal NetWeight, string flavor = "Ваниль") : base("Сироп", NetWeight)
    {
        Flavor = flavor;
    }
    public override string Name => "Сироп";
}