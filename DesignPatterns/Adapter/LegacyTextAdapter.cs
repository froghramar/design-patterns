namespace DesignPatterns.Adapter;

public class LegacyTextAdapter : ITextProvider
{
    private readonly LegacyTextService _legacy;

    public LegacyTextAdapter(LegacyTextService legacy)
    {
        _legacy = legacy ?? throw new ArgumentNullException(nameof(legacy));
    }

    public string GetText() => _legacy.Fetch();
}
