using System;
using System.Linq;
using System.Collections.Generic;

namespace DrinkApp
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("~~~ КОФЕЙНЯ ~~~");
                Console.WriteLine("1. Создать новый напиток");
                Console.WriteLine("2. Редактировать напиток");
                Console.WriteLine("3. Удалить напиток");
                Console.WriteLine("4. Список напитков");
                Console.WriteLine("0. Выход");
                Console.Write("\nВыберите действие: ");
                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateNewDrink();
                        break;
                    case "2":
                        EditDrink();
                        break;
                    case "3":
                        DeleteDrink();
                        break;
                    case "4":
                        ShowDrink();
                        break;
                    case "0":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Неверный выбор");
                        Console.ReadLine();
                        break;
                }
            }
        }

        static void CreateNewDrink()
        {
            Console.Clear();
            Console.Write("Введите название напитка: ");
            string? name = Console.ReadLine();

            if (!string.IsNullOrEmpty(name))
            {
                if (Storage.Drinks.Any(d => d.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine($"\nНапиток '{name}' уже существует");
                    Console.WriteLine("Нажмите любую клавишу");
                    Console.ReadLine();
                    return;
                }

                Drink currentDrink = new Drink(name);
                MainPage.MainUI(currentDrink);
            }
            else
            {
                Console.WriteLine("Название не может быть пустым");
                Console.ReadLine();
            }
        }

        static void EditDrink()
        {
            Console.Clear();
            
            if (Storage.Drinks.Count == 0)
            {
                Console.WriteLine("Нет сохраненных напитков для редактирования.");
                Console.WriteLine("Нажмите любую клавишу");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Выберите напиток для редактирования\n");
            
            for (int i = 0; i < Storage.Drinks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Storage.Drinks[i].Name}");
            }
            
            Console.WriteLine("\nВведите номер напитка: ");
            
            if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= Storage.Drinks.Count)
            {
                Drink selectedDrink = Storage.Drinks[index - 1];
                MainPage.MainUI(selectedDrink);
            }
            else
            {
                Console.WriteLine("Неверный выбор");
                Console.WriteLine("Нажмите любую клавишу");
                Console.ReadLine();
            }
        }

        static void DeleteDrink()
        {
            Console.Clear();
            
            if (Storage.Drinks.Count == 0)
            {
                Console.WriteLine("Нет сохраненных напитков для удаления.");
                Console.WriteLine("Нажмите любую клавишу");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Выберите напиток для удаления\n");
            
            for (int i = 0; i < Storage.Drinks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Storage.Drinks[i].Name}");
            }
            
            Console.Write("Введите номер напитка: ");
            
            if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= Storage.Drinks.Count)
            {
                Drink selectedDrink = Storage.Drinks[index - 1];
                Console.WriteLine($"\nВы уверены, что хотите удалить '{selectedDrink.Name}'?");
                Console.WriteLine("1. Да");
                Console.WriteLine("2. Нет");
                Console.Write("\nВаш выбор: ");
                
                string? confirm = Console.ReadLine();
                if (confirm == "1")
                {
                    Storage.Drinks.RemoveAt(index - 1);
                    Console.WriteLine($"\n✓ Напиток '{selectedDrink.Name}' удалён");
                }
                else
                {
                    Console.WriteLine("\nУдаление отменено");
                }
            }
            else
            {
                Console.WriteLine("Неверный выбор");
            }
            
            Console.WriteLine("\nНажмите любую клавишу");
            Console.ReadLine();
        }

        static void ShowDrink()
        {
            Console.Clear();
            
            if (Storage.Drinks.Count == 0)
            {
                Console.WriteLine("Список напитков пуст");
            }
            else
            {
                Console.WriteLine("~~~ СПИСОК НАПИТКОВ ~~~\n");
                for (int i = 0; i < Storage.Drinks.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {Storage.Drinks[i].Name}");
                    
                    var ingredients = Storage.Drinks[i].GetIngredients();
                    if (ingredients.Count > 0)
                    {
                        Console.WriteLine($"   Ингредиентов: {ingredients.Count}");
                    }
                }
                Console.WriteLine($"\nВсего: {Storage.Drinks.Count} напитков");
            }
            
            Console.WriteLine("\nНажмите любую клавишу");
            Console.ReadLine();
        }
    }
}