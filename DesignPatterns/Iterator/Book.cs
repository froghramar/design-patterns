namespace DesignPatterns.Iterator;

public sealed class Book
{
    public string Title { get; }
    public string Author { get; }

    public Book(string title, string author)
    {
        Title = title ?? string.Empty;
        Author = author ?? string.Empty;
    }

    public override string ToString() => $"{Title} by {Author}";
}
