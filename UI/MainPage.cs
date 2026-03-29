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
                    Console.WriteLine("Некорректный выбор");
                    Console.ReadLine();
                    break;
            }
        }
    }
    private static string GetIngredientName(IngredientType type)
    {
        switch (type)
        {
            case IngredientType.Coffee: return "Кофе";
            case IngredientType.Ice: return "Лёд";
            case IngredientType.Milk: return "Молоко";
            case IngredientType.Syrup: return "Сироп";
            case IngredientType.Water: return "Вода";
            default: return "Неизвестно";
        }
    }

    private static string GetActionName(ActionType type)
    {
        switch (type)
        {
            case ActionType.Beat: return "Взбить";
            case ActionType.Boil: return "Вскипятить";
            case ActionType.Grind: return "Перемолоть";
            case ActionType.Mix: return "Перемешать";
            case ActionType.Pour: return "Пролить";
            default: return "Неизвестно";
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
                    AddIngredient(drink, IngredientType.Water);
                    break;
                case "2":
                    AddIngredient(drink, IngredientType.Syrup);
                    break;
                case "3":
                    AddIngredient(drink, IngredientType.Coffee);
                    break;
                case "4":
                    AddIngredient(drink, IngredientType.Milk);
                    break;
                case "5":
                    AddIngredient(drink, IngredientType.Ice);
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Некорректный выбор");
                    Console.ReadLine();
                    break;
            }
        }
    }
    public static void AddIngredient(Drink drink, IngredientType type)
    {
        string name = GetIngredientName(type);
        
        Console.Clear();
        Console.WriteLine($"~~~ Добавление {name} ~~~");
        
        Console.Write("Введите вес нетто (грамм): ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal weight) || weight <= 0)
        {
            Console.WriteLine("Ошибка: введите корректное число!");
            Console.ReadLine();
            return;
        }
        
        Ingredient ingredient = Ingredient.Create(type, weight);
        Console.Clear();
        ingredient.GetParametersFromUser();
        drink.AddIngredient(ingredient);
        ingredient.AddMessage();
        
        Console.WriteLine("\nНажмите любую клавишу");
        Console.ReadLine();
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