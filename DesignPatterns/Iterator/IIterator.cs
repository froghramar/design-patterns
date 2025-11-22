namespace DesignPatterns.Iterator;

public interface IIterator
{
    bool HasNext();
    Book Next();
}
