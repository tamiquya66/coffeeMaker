using System;
using System.Linq;
using System.Collections.Generic;

namespace DrinkApp{
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
        public void Display()
        {
            Console.Clear();
            Console.WriteLine("Текущий рецепт");
            foreach(Element el in _elements)
            {
                Console.WriteLine($"{el}, ");
            }
        }
        public void AddIngredient()
        {
            Console.Clear();
            
        }
        public void AddAction()
        {
            
        }
    }
}