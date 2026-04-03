using System;

namespace DrinkApp
{
    public class MixAction : Action
    {
        public int Speed { get; }
        public int DurationSeconds { get; }

        public MixAction(int speed, int durationSeconds)
            : base("Перемешать")
        {
            Speed = speed;
            DurationSeconds = durationSeconds;
        }

        public override void Display(int i = 0)
        {
            string padding = new string(' ', i * 2);
            Console.WriteLine($"{padding} ▸ {Name}: скорость {Speed}, {DurationSeconds}сек");

            foreach (var element in _elements)
            {
                element.Display(i + 1);
            }
        }

        public override void Execute()
        {
            Console.WriteLine($"Перемешано {DurationSeconds} сек на скорости {Speed}");
            foreach (var element in _elements)
            {
                element.Execute();
            }
        }
    }
}