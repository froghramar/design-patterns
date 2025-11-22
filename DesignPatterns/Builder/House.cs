namespace DesignPatterns.Builder;

public sealed class House
{
    public int Rooms { get; }
    public int Windows { get; }
    public bool HasGarage { get; }
    public string Address { get; }

    public House(int rooms, int windows, bool hasGarage, string address)
    {
        if (rooms < 0) throw new ArgumentOutOfRangeException(nameof(rooms));
        if (windows < 0) throw new ArgumentOutOfRangeException(nameof(windows));
        Address = address ?? string.Empty;
        Rooms = rooms;
        Windows = windows;
        HasGarage = hasGarage;
    }

    public override string ToString() => $"House: {Rooms} rooms, {Windows} windows, Garage: {HasGarage}, Address: {Address}";
}
