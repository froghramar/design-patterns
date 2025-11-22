using DesignPatterns.Mediator;

namespace Tests;

public class MediatorTests
{
    [Fact]
    public void Participants_CanSendMessagesViaChatRoom()
    {
        var room = new ChatRoom();
        var alice = new Participant("Alice");
        var bob = new Participant("Bob");

        room.Register(alice);
        room.Register(bob);

        alice.Send("Hello Bob");

        Assert.Contains("Alice: Hello Bob", bob.Messages);
        Assert.Empty(alice.Messages); // sender shouldn't receive own message
    }
}
