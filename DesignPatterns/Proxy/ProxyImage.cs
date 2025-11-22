namespace DesignPatterns.Proxy;

public class ProxyImage : IImage
{
    private readonly string _filename;
    private RealImage? _real;

    public ProxyImage(string filename)
    {
        _filename = filename;
    }

    public void Display()
    {
        if (_real is null)
        {
            _real = new RealImage(_filename);
        }
        _real.Display();
    }
}
