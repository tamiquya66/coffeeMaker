using System;

namespace DrinkApp
{
    public class AddAction : Action
    {
        private Ingredient? _ingredient;

        public Ingredient? TargetIngredient => _ingredient;

        public AddAction(Ingredient ingredient) : base("Добавить")
        {
            _ingredient = ingredient;
        }
        public AddAction() : base("Добавить")
        {
            _ingredient = null;
        }

        public override void Display(int i = 0)
        {
            string padding = new string(' ', i * 2);
            
            if (_ingredient != null)
            {
                Console.WriteLine($"{padding}• {_ingredient.Name} ({_ingredient.NetWeight}г)");
            }
            else
            {
                Console.WriteLine($"{padding} {Name}");
            }

            foreach (var element in _elements)
            {
                element.Display(i + 1);
            }
        }

        public override void Execute()
        {
            if (_ingredient != null)
            {
                _ingredient.AddMessage();
            }

            foreach (var element in _elements)
            {
                element.Execute();
            }
        }
    }
}