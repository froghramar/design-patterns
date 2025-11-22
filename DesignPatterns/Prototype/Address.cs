namespace DesignPatterns.Prototype;

public sealed class Address
{
    public string Street { get; set; }
    public string City { get; set; }

    public Address(string street, string city)
    {
        Street = street ?? string.Empty;
        City = city ?? string.Empty;
    }

    public Address Clone() => new Address(Street, City);

    public override string ToString() => $"{Street}, {City}";
}
