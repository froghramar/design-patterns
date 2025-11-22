using DesignPatterns.Bridge;

namespace Tests;

public class BridgeTests
{
    [Fact]
    public void RemoteControl_CanToggleDeviceAndChangeVolume()
    {
        var tv = new Tv();
        var remote = new RemoteControl(tv);

        Assert.False(tv.IsEnabled);
        remote.TogglePower();
        Assert.True(tv.IsEnabled);

        remote.VolumeUp();
        Assert.Equal(10, tv.Volume);

        remote.SetChannel(5);
        Assert.Equal(5, tv.Channel);
    }

    [Fact]
    public void AdvancedRemote_Mute_SetsVolumeToZero()
    {
        var radio = new Radio();
        var remote = new AdvancedRemote(radio);

        remote.VolumeUp(); // 10
        Assert.Equal(10, radio.Volume);

        remote.Mute();
        Assert.Equal(0, radio.Volume);
    }
}
