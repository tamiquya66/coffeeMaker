using System;

namespace DrinkApp
{
    public class GrindAction : Action
    {
        public string GrindSize { get; }

        public GrindAction(string grindSize)
            : base("Перемолоть")
        {
            GrindSize = grindSize;
        }

        public override void Display(int i = 0)
        {
            string padding = new string(' ', i * 2);
            Console.WriteLine($"{padding} ▸ {Name}: {GrindSize} помол");

            foreach (var element in _elements)
            {
                element.Display(i + 1);
            }
        }

        public override void Execute()
        {
            Console.WriteLine($"Перемолото до {GrindSize} помола");
            foreach (var element in _elements)
            {
                element.Execute();
            }
        }
    }
}