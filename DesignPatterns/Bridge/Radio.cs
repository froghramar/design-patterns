namespace DesignPatterns.Bridge;

public class Radio : IDevice
{
    public bool IsEnabled { get; private set; }
    public int Volume { get; private set; }
    public int Channel { get; private set; }

    public void Enable() => IsEnabled = true;
    public void Disable() => IsEnabled = false;
    public void SetVolume(int percent) => Volume = Math.Clamp(percent, 0, 100);
    public void SetChannel(int channel) => Channel = channel;
}
