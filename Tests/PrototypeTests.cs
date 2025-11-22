using DesignPatterns.Prototype;

namespace Tests;

public class PrototypeTests
{
    [Fact]
    public void Person_Clone_CreatesDistinctCopy()
    {
        var original = new Person("Alice", 30, new Address("1 A St", "Townsville"));
        var clone = original.Clone();

        // different references
        Assert.NotSame(original, clone);
        Assert.NotSame(original.Address, clone.Address);

        // same values
        Assert.Equal(original.Name, clone.Name);
        Assert.Equal(original.Age, clone.Age);
        Assert.Equal(original.Address.Street, clone.Address.Street);
        Assert.Equal(original.Address.City, clone.Address.City);

        // modifying clone's address should not affect original
        clone.Address.Street = "2 B Ave";
        Assert.NotEqual(original.Address.Street, clone.Address.Street);
    }
}
