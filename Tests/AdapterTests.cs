using DesignPatterns.Adapter;

namespace Tests;

public class AdapterTests
{
    [Fact]
    public void Adapter_ProvidesTextFromLegacyService()
    {
        var legacy = new LegacyTextService();
        ITextProvider provider = new LegacyTextAdapter(legacy);

        Assert.Equal("Text from legacy service", provider.GetText());
    }
}
