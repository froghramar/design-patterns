using DesignPatterns.State;
using Xunit;

namespace Tests
{
    public class StateTests
    {
        [Fact]
        public void Document_State_Transitions_And_Behavior()
        {
            var doc = new Document("Hello");
            Assert.Equal("Draft", doc.StateName);

            // edit in draft
            doc.Edit("Hello Draft");
            Assert.Equal("Hello Draft", doc.Content);

            // publish -> moderation
            doc.Publish();
            Assert.Equal("Moderation", doc.StateName);

            // editing in moderation should throw
            Assert.Throws<InvalidOperationException>(() => doc.Edit("Should fail"));

            // publish -> published
            doc.Publish();
            Assert.Equal("Published", doc.StateName);

            // editing published moves back to draft and updates content
            doc.Edit("Updated after publish");
            Assert.Equal("Draft", doc.StateName);
            Assert.Equal("Updated after publish", doc.Content);
        }
    }
}
