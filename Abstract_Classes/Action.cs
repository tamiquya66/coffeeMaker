using System;

namespace DrinkApp
{
    public abstract class Action : Element
    {
        public virtual string Name { get; set; }
        public List<Element> _elements = new List<Element>();

        protected Action(string name)
        {
            Name = name;
        }

        public virtual void AddElement(Element element)
        {
            _elements.Add(element);
        }

        public void RemoveElement(Element element)
        {
            _elements.Remove(element);
        }

        public abstract void Display(int i = 0);
        public abstract void Execute();

        public void AddMessage()
        {
            Console.WriteLine($"Действие: {Name}");
        }
    }
}