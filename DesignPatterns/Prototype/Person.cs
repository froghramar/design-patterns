namespace DesignPatterns.Prototype;

public sealed class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public Address Address { get; set; }

    public Person(string name, int age, Address address)
    {
        Name = name ?? string.Empty;
        Age = age;
        Address = address ?? new Address(string.Empty, string.Empty);
    }

    // Deep clone
    public Person Clone() => new Person(Name, Age, Address.Clone());

    public override string ToString() => $"{Name}, {Age} years, Address: {Address}";
}
