using System;
using System.Linq;
using System.Collections.Generic;

namespace DrinkApp{
    class Program
    {
        static void Main()
        {
            Console.Clear();
            Console.WriteLine("~~~ КОФЕЙНЯ ~~~");
            Console.WriteLine("1. Приготовить напиток");
            Console.WriteLine("2. Список напитков");
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string? name = Console.ReadLine();
                    while (true)
                    {
                        Console.Clear();
                        Console.Write("Введите название напитка: ");
                        name = Console.ReadLine();
                        if (name != null) break;
                        Console.WriteLine("Ошибка: имя не может быть пустым");
                    }
                    Drink? currentDrink = new Drink(name);
                    break;
                case "2": 
                    break;
            }


            while (true)
            {
                MainPage.MainUI(currentDrink);
            }
        }
    }
}