
namespace FlexiDialog;

public interface IDialogService
{
    event Func<Task>? OnStateHasChanged;

    Task<DialogRef> OpenAsync<T>(DialogOption option);

    Task<DialogRef> OpenAsync(Type componentType, DialogOption option);

    void Close(DialogRef dialogRef);

    List<DialogRef> GetOpenDialogs();
}