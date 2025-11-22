using DesignPatterns.Builder;

namespace Tests;

public class BuilderTests
{
    [Fact]
    public void HouseBuilder_BuildsHouseWithSpecifiedProperties()
    {
        var house = new HouseBuilder()
            .WithRooms(3)
            .WithWindows(5)
            .WithGarage()
            .AtAddress("123 Main St")
            .Build();

        Assert.Equal(3, house.Rooms);
        Assert.Equal(5, house.Windows);
        Assert.True(house.HasGarage);
        Assert.Equal("123 Main St", house.Address);
    }

    [Fact]
    public void HouseBuilder_DefaultsWhenNotSpecified()
    {
        var house = new HouseBuilder().Build();

        Assert.Equal(0, house.Rooms);
        Assert.Equal(0, house.Windows);
        Assert.False(house.HasGarage);
        Assert.Equal(string.Empty, house.Address);
    }
}
