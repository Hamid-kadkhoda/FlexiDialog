
namespace FlexiDialog;

public class DialogService : IDialogService
{
    public event Func<Task>? OnStateHasChanged;

    private readonly List<DialogRef> _openDialogs = new List<DialogRef>();

    private int _highestZIndex = 1000;

    private async Task NotifyStateHasChangedAsync()
    {
        if (OnStateHasChanged != null)
        {
            await Task.WhenAll(OnStateHasChanged.GetInvocationList().Cast<Func<Task>>().Select(func => func()));
        }
    }

    public Task<DialogRef> OpenAsync<T>(DialogOption option)
    {
        return OpenAsync(typeof(T), option);
    }

    public async Task<DialogRef> OpenAsync(Type componentType, DialogOption option)
    {
        await NotifyStateHasChangedAsync();

        option.ZIndex = _highestZIndex;
        _highestZIndex++;

        var dialogRef = new DialogRef
        {
            DialogComponent = componentType,
            Parameters = new Dictionary<string, object>(),
            Options = option
        };

        _openDialogs.Add(dialogRef);
        await NotifyStateHasChangedAsync();

        return dialogRef;
    }

    public void Close(DialogRef dialogRef)
    {
        dialogRef.OnClosing?.Invoke();
        if (_openDialogs.Remove(dialogRef))
        {
            NotifyStateHasChangedAsync().Wait();
        }
    }

    public List<DialogRef> GetOpenDialogs()
    {
        return _openDialogs;
    }
}