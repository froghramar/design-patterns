namespace DesignPatterns.Builder;

public class HouseBuilder
{
    private int _rooms;
    private int _windows;
    private bool _hasGarage;
    private string _address = string.Empty;

    public HouseBuilder WithRooms(int rooms)
    {
        _rooms = rooms;
        return this;
    }

    public HouseBuilder WithWindows(int windows)
    {
        _windows = windows;
        return this;
    }

    public HouseBuilder WithGarage(bool hasGarage = true)
    {
        _hasGarage = hasGarage;
        return this;
    }

    public HouseBuilder AtAddress(string address)
    {
        _address = address ?? string.Empty;
        return this;
    }

    public House Build()
    {
        return new House(_rooms, _windows, _hasGarage, _address);
    }
}
