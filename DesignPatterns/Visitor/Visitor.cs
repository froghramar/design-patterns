using System.Collections.Generic;

namespace DesignPatterns.Visitor
{
    public interface IVisitor
    {
        void Visit(ElementA element);
        void Visit(ElementB element);
    }

    public interface IElement
    {
        void Accept(IVisitor visitor);
    }

    public class ElementA : IElement
    {
        public string Name { get; }

        public ElementA(string name) => Name = name;

        public void Accept(IVisitor visitor) => visitor.Visit(this);

        public override string ToString() => $"ElementA({Name})";
    }

    public class ElementB : IElement
    {
        public int Value { get; }

        public ElementB(int value) => Value = value;

        public void Accept(IVisitor visitor) => visitor.Visit(this);

        public override string ToString() => $"ElementB({Value})";
    }

    public class ConcreteVisitor : IVisitor
    {
        public List<string> Log { get; } = new();

        public void Visit(ElementA element)
        {
            Log.Add($"Visited A:{element.Name}");
        }

        public void Visit(ElementB element)
        {
            Log.Add($"Visited B:{element.Value}");
        }
    }

    public class ObjectStructure
    {
        private readonly List<IElement> _elements = new();

        public void Add(IElement element) => _elements.Add(element);

        public void Accept(IVisitor visitor)
        {
            foreach (var e in _elements)
            {
                e.Accept(visitor);
            }
        }
    }
}
