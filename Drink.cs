using System;
using System.Collections.Generic;

namespace DrinkApp
{
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
        public Element? _element;

        public Drink(string name)
        {
            if (name == null) throw new ArgumentNullException("Имя не может быть пустым");
            _name = name;
        }

        public void SetElement(Element element)
        {
            _element = element;
        }

        public void DisplayRecipe()
        {
            Console.Clear();
            Console.WriteLine($"~~~ {_name} ~~~\n");

            if (_element == null)
            {
                Console.WriteLine("  (рецепт пуст)");
                return;
            }

            _element.Display(0);
            Console.ReadLine();
        }

        public List<Ingredient> GetIngredients()
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            if (_element is Action action)
            {
                CollectIngredients(action, ingredients);
            }
            return ingredients;
        }

        private void CollectIngredients(Action action, List<Ingredient> ingredients)
        {
            foreach (var element in action._elements)
            {
                if (element is AddAction addAction && addAction.TargetIngredient != null)
                {
                    ingredients.Add(addAction.TargetIngredient);
                }
                else if (element is Action subAction)
                {
                    CollectIngredients(subAction, ingredients);
                }
            }
        }

        public List<Action> GetActions()
        {
            List<Action> actions = new List<Action>();
            if (_element is Action rootAction)
            {
                CollectActions(rootAction, actions);
            }
            return actions;
        }

        private void CollectActions(Action action, List<Action> actions)
        {
            foreach (var element in action._elements)
            {
                if (element is Action subAction)
                {
                    actions.Add(subAction);
                    CollectActions(subAction, actions);
                }
            }
        }
        public AddAction? FindAddAction(Ingredient ingredient)
        {
            if (_element is Action action)
            {
                return FindAddActionInAction(action, ingredient);
            }
            return null;
        }

        private AddAction? FindAddActionInAction(Action action, Ingredient ingredient)
        {
            foreach (var element in action._elements)
            {
                if (element is AddAction addAction && addAction.TargetIngredient == ingredient)
                {
                    return addAction;
                }
                else if (element is Action subAction)
                {
                    var result = FindAddActionInAction(subAction, ingredient);
                    if (result != null) return result;
                }
            }
            return null;
        }
        public Action? GetRootAction()
        {
            if (_element is Action action)
            {
                return action;
            }
            return null;
        }
    }
}