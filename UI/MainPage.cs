using DrinkApp;

public class MainPage
{
    public static void MainUI(Drink drink)
    {
        while (true)
        {   
            Console.Clear();
            Console.WriteLine($"~~~ Создание напитка {drink.Name} ~~~");
            Console.WriteLine("1. Добавление ингредиента");
            Console.WriteLine("2. Добавление действия");
            Console.WriteLine("3. Удаление действия");
            Console.WriteLine("4. Показать рецепт");
            Console.WriteLine("0. Выход");
            Console.Write("Выберите действие: ");
            
            string? choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    drink.AddIngredient();
                    break;
                case "2":
                    drink.AddAction();
                    break;
            }
        }
    }
}