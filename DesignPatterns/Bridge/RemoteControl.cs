namespace DesignPatterns.Bridge;

public class RemoteControl
{
    protected IDevice Device;

    public RemoteControl(IDevice device)
    {
        Device = device;
    }

    public virtual void TogglePower()
    {
        if (Device.IsEnabled) Device.Disable(); else Device.Enable();
    }

    public virtual void VolumeUp() => Device.SetVolume(Device.Volume + 10);
    public virtual void VolumeDown() => Device.SetVolume(Device.Volume - 10);
    public virtual void SetChannel(int channel) => Device.SetChannel(channel);
}
