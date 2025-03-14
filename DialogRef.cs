
namespace FlexiDialog;

public class DialogRef
{
    public Type? DialogComponent { get; set; }

    public Guid Key { get; private init; } = Guid.NewGuid();

    public Dictionary<string, object> Parameters { get; set; } = [];

    public DialogOption Options { get; set; } = new();

    public Func<Task>? OnClosing { get; set; }
}