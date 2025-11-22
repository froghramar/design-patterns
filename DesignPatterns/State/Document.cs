namespace DesignPatterns.State
{
    public interface IDocumentState
    {
        string Name { get; }
        void Publish(Document doc);
        void Edit(Document doc, string content);
    }

    public class Document
    {
        public string Content { get; private set; }
        public IDocumentState State { get; internal set; }

        public Document(string initialContent)
        {
            Content = initialContent;
            State = new DraftState();
        }

        public string StateName => State.Name;

        public void Publish() => State.Publish(this);

        public void Edit(string content) => State.Edit(this, content);

        internal void SetContent(string content) => Content = content;
    }

    internal class DraftState : IDocumentState
    {
        public string Name => "Draft";

        public void Publish(Document doc)
        {
            // move to moderation for review
            doc.State = new ModerationState();
        }

        public void Edit(Document doc, string content)
        {
            doc.SetContent(content);
        }
    }

    internal class ModerationState : IDocumentState
    {
        public string Name => "Moderation";

        public void Publish(Document doc)
        {
            // approved -> published
            doc.State = new PublishedState();
        }

        public void Edit(Document doc, string content)
        {
            // cannot edit while under moderation
            throw new InvalidOperationException("Cannot edit document while under moderation");
        }
    }

    internal class PublishedState : IDocumentState
    {
        public string Name => "Published";

        public void Publish(Document doc)
        {
            // already published; no-op
        }

        public void Edit(Document doc, string content)
        {
            // editing a published document returns it to draft
            doc.SetContent(content);
            doc.State = new DraftState();
        }
    }
}
