namespace DesignPatterns.Command;

public class Light
{
    public bool IsOn { get; private set; }

    public void On() => IsOn = true;
    public void Off() => IsOn = false;
}
