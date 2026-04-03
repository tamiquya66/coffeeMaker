using System;

namespace DrinkApp
{
    public class PourAction : Action
    {
        public string To { get; }

        public PourAction(string to) : base("Перелить")
        {
            To = to;
        }

        public override void Display(int i = 0)
        {
            string padding = new string(' ', i * 2);
            Console.WriteLine($"{padding} ▸ {Name} → {To}");

            foreach (var element in _elements)
            {
                element.Display(i + 1);
            }
        }

        public override void Execute()
        {
            Console.WriteLine($"Перелито в {To}");
            foreach (var element in _elements)
            {
                element.Execute();
            }
        }
    }
}