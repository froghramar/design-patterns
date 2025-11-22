namespace DesignPatterns.Facade;

internal class PaymentProcessor
{
    public bool Charge(string customer, decimal amount)
    {
        // Simulate always successful payment for example
        return amount > 0;
    }
}
