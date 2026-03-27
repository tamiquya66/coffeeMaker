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
            Console.WriteLine("3. Удаление ингредиента");
            Console.WriteLine("4. Удаление действия");
            Console.WriteLine("5. Показать рецепт");
            Console.WriteLine("0. Выход");
            Console.Write("\nВыберите действие: ");
            
            string? choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    IngredientMenu(drink);
                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    break;
                case "5":
                    drink.DisplayRecipe();
                    break;
                case "0":
                    return;
                default:
                    throw new ArgumentException("Некорректный выбор");
            }
        }
    }

    public static void IngredientMenu(Drink drink)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("~~~ Добавление ингредиента ~~~");
            Console.WriteLine("1. Вода");
            Console.WriteLine("2. Сироп");
            Console.WriteLine("3. Кофейное зерно");
            Console.WriteLine("4. Молоко");
            Console.WriteLine("5. Лёд");
            Console.WriteLine("0. Назад");
            Console.Write("\nВыберите ингредиент: ");
            
            string? choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    drink.AddIngredient(drink, IngredientType.Water);
                    break;
                case "2":
                    drink.AddIngredient(drink, IngredientType.Syrup);
                    break;
                case "3":
                    drink.AddIngredient(drink, IngredientType.Coffee);
                    break;
                case "4":
                    drink.AddIngredient(drink, IngredientType.Milk);
                    break;
                case "5":
                    drink.AddIngredient(drink, IngredientType.Ice);
                    break;
                case "0":
                    return;
                default:
                    throw new ArgumentException("Некорректный выбор ингредиента");
            }
        }
    }
    public static void ActionMenu(Drink drink)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("~~~ Добавление действия ~~~");
            Console.WriteLine("1. Перемешать");
            Console.WriteLine("2. Вскипятить");
            Console.WriteLine("3. Пролить");
            Console.WriteLine("4. Перемолоть");
            Console.WriteLine("5. Взбить");
            Console.WriteLine("0. Назад");
            Console.Write("\nВыберите ингредиент: ");
            
            string? choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    drink.AddAction(drink, ActionType.Mix);
                    break;
                case "2":
                    drink.AddAction(drink, ActionType.Boil);
                    break;
                case "3":
                    drink.AddAction(drink, ActionType.Pour);
                    break;
                case "4":
                    drink.AddAction(drink, ActionType.Grind);
                    break;
                case "5":
                    drink.AddAction(drink, ActionType.Beat);
                    break;
                case "0":
                    return;
                default:
                    throw new ArgumentException("Некорректный выбор ингредиента");
            }
        }
    }
}