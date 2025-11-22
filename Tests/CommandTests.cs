using DesignPatterns.Command;

namespace Tests;

public class CommandTests
{
    [Fact]
    public void LightOnCommand_ExecutesAndUndo()
    {
        var light = new Light();
        var on = new LightOnCommand(light);

        var remote = new RemoteControl();
        remote.SetCommand(on);

        remote.PressButton();
        Assert.True(light.IsOn);

        remote.PressUndo();
        Assert.False(light.IsOn);
    }

    [Fact]
    public void LightOffCommand_ExecutesAndUndo()
    {
        var light = new Light();
        light.On();
        var off = new LightOffCommand(light);

        var remote = new RemoteControl();
        remote.SetCommand(off);

        remote.PressButton();
        Assert.False(light.IsOn);

        remote.PressUndo();
        Assert.True(light.IsOn);
    }
}
