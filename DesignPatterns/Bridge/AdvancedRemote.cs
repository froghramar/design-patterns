namespace DesignPatterns.Bridge;

public class AdvancedRemote : RemoteControl
{
    public AdvancedRemote(IDevice device) : base(device) { }

    public void Mute() => Device.SetVolume(0);
}
