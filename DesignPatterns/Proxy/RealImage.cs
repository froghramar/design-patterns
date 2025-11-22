namespace DesignPatterns.Proxy;

public class RealImage : IImage
{
    private readonly string _filename;

    public RealImage(string filename)
    {
        _filename = filename;
        LoadFromDisk();
    }

    private void LoadFromDisk()
    {
        // Simulate expensive load
    }

    public void Display()
    {
        Console.WriteLine($"Displaying {_filename}");
    }
}
