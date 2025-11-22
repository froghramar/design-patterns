namespace DesignPatterns.Adapter;

// A legacy service with a different API we want to adapt.
public class LegacyTextService
{
    public string Fetch() => "Text from legacy service";
}
