using System;
using System.Linq;
using System.Collections.Generic;

namespace DrinkApp{
    public enum IngredientType
    {
        Water,
        Syrup,
        Coffee,
        Milk,
        Ice
    }
    public enum ActionType
    {
        Mix,
        Boil,
        Pour,
        Grind,
        Beat
    }
    public class Drink
    {
        private string _name;
        public string Name => _name;
        private List<Element> _elements = new List<Element>();
        public Drink(string? name)
        {
            if (name == null) throw new ArgumentNullException("Имя не может быть пустым");
            _name = name;
        }
        public void AddElement(Element element)
        {
            Console.Clear();
            _elements.Add(element);
            element.AddMessage();
        }
        public void DisplayRecipe()
        {
            Console.Clear();
            Console.WriteLine("Текущий рецепт");
            foreach(Element el in _elements)
            {
                Console.WriteLine($"{el}, ");
            }
        }
        public void AddIngredient(Drink drink, IngredientType type)
        {
            Console.Clear();
            Console.WriteLine("Введите вес нетто");
            string? input = Console.ReadLine();

            decimal weight;
            while (!decimal.TryParse(input, out weight) && weight < 0){
                Console.WriteLine("Некорректный ввод");
            }

            Ingredient ingredient = Ingredient.Create(type, weight);
            AddElement(ingredient);
            Console.WriteLine($"Успешно добавлен {ingredient.Name}");
            Console.WriteLine("\nВведите любое число");
            Console.ReadLine();
        }
        public void AddAction(Drink drink, ActionType type)
        {
            Console.Clear();
            Console.WriteLine();
        }
    }
}