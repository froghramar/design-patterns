namespace DesignPatterns.Bridge;

public interface IDevice
{
    bool IsEnabled { get; }
    int Volume { get; }
    int Channel { get; }

    void Enable();
    void Disable();
    void SetVolume(int percent); // 0 - 100
    void SetChannel(int channel);
}
