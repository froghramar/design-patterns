namespace DesignPatterns.Iterator;

public class BookIterator : IIterator
{
    private readonly List<Book> _books;
    private int _position = 0;

    public BookIterator(List<Book> books)
    {
        _books = books ?? new List<Book>();
    }

    public bool HasNext() => _position < _books.Count;

    public Book Next()
    {
        if (!HasNext()) throw new InvalidOperationException();
        return _books[_position++];
    }
}
