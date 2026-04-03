using System;
using System.Collections.Generic;

namespace DrinkApp
{
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
                        ActionMenu(drink);
                        break;
                    case "3":
                        
                        break;
                    case "4":
                        
                        break;
                    case "5":
                        drink.DisplayRecipe();
                        break;
                    case "0":
                        Console.WriteLine("До свидания!");
                        Environment.Exit(0);
                        break;
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
                case ActionType.Whisk: return "Взбить";
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
            ingredient.GetParametersFromUser();

            var addAction = new AddAction(ingredient);

            if (drink.GetRootAction() == null)
            {
                var rootAction = new AddAction();
                rootAction.AddElement(addAction);
                drink.SetElement(rootAction);
            }
            else
            {
                drink.GetRootAction().AddElement(addAction);
            }

            Console.WriteLine();
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
                Console.Write("\nВыберите действие: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddActionToIngredient(drink, ActionType.Mix);
                        break;
                    case "2":
                        AddActionToIngredient(drink, ActionType.Boil);
                        break;
                    case "3":
                        AddActionToIngredient(drink, ActionType.Pour);
                        break;
                    case "4":
                        AddActionToIngredient(drink, ActionType.Grind);
                        break;
                    case "5":
                        AddActionToIngredient(drink, ActionType.Whisk);
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

        public static void AddActionToIngredient(Drink drink, ActionType type)
        {
            string name = GetActionName(type);

            Console.Clear();
            Console.WriteLine($"~~~ Действие {name} ~~~");

            var ingredients = drink.GetIngredients();

            if (ingredients.Count == 0)
            {
                Console.WriteLine("Список ингредиентов пуст. Сначала добавьте ингредиент!");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("\nВыберите ингредиент для этого действия:");
            for (int i = 0; i < ingredients.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {ingredients[i].Name} ({ingredients[i].NetWeight}г)");
            }
            Console.Write("Ваш выбор: ");

            if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > ingredients.Count)
            {
                Console.WriteLine("Неверный выбор!");
                Console.ReadLine();
                return;
            }

            Ingredient selectedIngredient = ingredients[choice - 1];

            Action? action = null;

            Console.Clear();
            switch (type)
            {
                case ActionType.Mix:
                    int speed = 0;
                    int duration = 0;

                    while (true)
                    {
                        Console.Write("Скорость (1-10): ");
                        if (int.TryParse(Console.ReadLine(), out speed) && speed >= 1 && speed <= 10) break;
                        Console.WriteLine("Ошибка: введите число от 1 до 10");
                    }

                    while (true)
                    {
                        Console.Write("Время (секунд): ");
                        if (int.TryParse(Console.ReadLine(), out duration) && duration > 0) break;
                        Console.WriteLine("Ошибка: введите положительное число");
                    }

                    action = new MixAction(speed, duration);
                    break;

                case ActionType.Boil:
                    int temp = 0;
                    int minutes = 0;

                    while (true)
                    {
                        Console.Write("Температура (°C): ");
                        if (int.TryParse(Console.ReadLine(), out temp) && temp > 0 && temp <= 150) break;
                        Console.WriteLine("Ошибка: введите температуру от 1 до 150");
                    }

                    while (true)
                    {
                        Console.Write("Время (минут): ");
                        if (int.TryParse(Console.ReadLine(), out minutes) && minutes > 0) break;
                        Console.WriteLine("Ошибка: введите положительное число");
                    }

                    action = new BoilAction(temp, minutes);
                    break;

                case ActionType.Pour:
                    Console.Write("Куда пролить: ");
                    string? to = Console.ReadLine();
                    while (string.IsNullOrWhiteSpace(to))
                    {
                        Console.Write("Куда пролить (не может быть пустым): ");
                        to = Console.ReadLine();
                    }
                    action = new PourAction(to);
                    break;

                case ActionType.Grind:
                    Console.Write("Степень помола (мелкий/средний/крупный): ");
                    string? grindSize = Console.ReadLine();
                    while (string.IsNullOrWhiteSpace(grindSize))
                    {
                        Console.Write("Степень помола (не может быть пустым): ");
                        grindSize = Console.ReadLine();
                    }
                    action = new GrindAction(grindSize);
                    break;

                case ActionType.Whisk:
                    int whiskSpeed = 0;
                    int whiskDuration = 0;

                    while (true)
                    {
                        Console.Write("Скорость (1-10): ");
                        if (int.TryParse(Console.ReadLine(), out whiskSpeed) && whiskSpeed >= 1 && whiskSpeed <= 10)
                            break;
                        Console.WriteLine("Ошибка: введите число от 1 до 10");
                    }

                    while (true)
                    {
                        Console.Write("Время (секунд): ");
                        if (int.TryParse(Console.ReadLine(), out whiskDuration) && whiskDuration > 0)
                            break;
                        Console.WriteLine("Ошибка: введите положительное число");
                    }

                    action = new WhiskAction(whiskSpeed, whiskDuration);
                    break;
            }

            if (action != null)
            {
                AddAction? addAction = drink.FindAddAction(selectedIngredient);
                if (addAction != null)
                {
                    addAction.AddElement(action);
                    Console.WriteLine();
                    action.Execute();
                    Console.WriteLine($"\n✓ {name} добавлен для {selectedIngredient.Name}");
                }
                else
                {
                    Console.WriteLine("Ошибка: не найден ингредиент в рецепте");
                }
            }

            Console.WriteLine("\nНажмите любую клавишу");
            Console.ReadLine();
        }
    }
}