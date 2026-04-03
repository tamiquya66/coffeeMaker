using System;

namespace DrinkApp
{
    public class BoilAction : Action
    {
        public int Temperature { get; }
        public int DurationMinutes { get; }

        public BoilAction(int temperature, int durationMinutes)
            : base("Вскипятить")
        {
            Temperature = temperature;
            DurationMinutes = durationMinutes;
        }

        public override void Display(int i = 0)
        {
            string padding = new string(' ', i * 2);
            Console.WriteLine($"{padding} ▸ {Name}: {Temperature}°C, {DurationMinutes}мин");

            foreach (var element in _elements)
            {
                element.Display(i + 1);
            }
        }

        public override void Execute()
        {
            Console.WriteLine($"Кипячение до {Temperature}°C за {DurationMinutes}мин");
            foreach (var element in _elements)
            {
                element.Execute();
            }
        }
    }
}