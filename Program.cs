using System;
using System.Linq;
using System.Collections.Generic;

namespace DrinkApp{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите название для напитка");
            string? name = Console.ReadLine();
            Drink currentDrink = new Drink(name);

            while (true)
            {
                MainPage.MainUI(currentDrink);
            }
        }
    }
}