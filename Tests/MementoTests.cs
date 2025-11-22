using DesignPatterns.Memento;

namespace Tests;

public class MementoTests
{
    [Fact]
    public void TextEditor_SaveAndRestore_Works()
    {
        var editor = new TextEditor();
        var caretaker = new CareTaker();

        editor.Type("Hello");
        caretaker.SaveState(editor.Save());

        editor.Type(" World");
        Assert.Equal("Hello World", editor.Text);

        var m = caretaker.PopState();
        editor.Restore(m!);

        Assert.Equal("Hello", editor.Text);
    }

    [Fact]
    public void CareTaker_ReturnsNullWhenEmpty()
    {
        var caretaker = new CareTaker();
        Assert.Null(caretaker.PopState());
    }
}
