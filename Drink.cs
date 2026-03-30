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
        Whisk
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
            Console.WriteLine($"~~~ {_name} ~~~\n");
            
            if (_elements.Count == 0)
            {
                Console.WriteLine("  (рецепт пуст)");
                return;
            }
            
            for (int i = 0; i < _elements.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                _elements[i].Display(0);
            }
            Console.ReadLine();
        }
        public void AddIngredient(Ingredient ingredient)
        {
            AddElement(new AddAction(ingredient));
        }
        public void AddAction(Action action)
        {
            AddElement(action);
        }
        public List<Ingredient> GetIngredients()
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            
            foreach (var element in _elements)
            {
                if (element == null) continue;
                
                if (element is AddAction addAction && addAction.TargetIngredient != null)
                {
                    ingredients.Add(addAction.TargetIngredient);
                }
            }
            
            return ingredients;
        }
        public AddAction FindAddAction(Ingredient ingredient)
        {
            foreach (var element in _elements)
            {
                if (element is AddAction addAction && addAction.TargetIngredient == ingredient)
                {
                    return addAction;
                }
            }
            return null;
        }
    }
}