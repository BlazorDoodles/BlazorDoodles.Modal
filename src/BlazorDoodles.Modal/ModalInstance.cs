namespace BlazorDoodles.Modal;

public class ModalInstance<TResponse> : IModalInstance
{
    protected readonly IModalService _modalService;
    protected readonly TaskCompletionSource<ModalResult<TResponse>> _resultCompletion;

    public Type ModalType { get; }
    public IDictionary<string, object?> Parameters { get; }

    public Task<ModalResult<TResponse>> Result => _resultCompletion.Task;

    public ModalInstance(IModalService modalService, Type modalType, IDictionary<string, object?> parameters)
    {
        _modalService = modalService;
        _resultCompletion = new(TaskCreationOptions.RunContinuationsAsynchronously);

        ModalType = modalType;
        Parameters = parameters;
        Parameters.Add(nameof(ModalBase.Modal), this);
    }

    public void Cancel()
    {
        _resultCompletion.TrySetResult(ModalResult.Cancel<TResponse>());
        _modalService.Close(this);
    }

    public void Close(TResponse response)
    {
        _resultCompletion.TrySetResult(ModalResult.Ok(response));
        _modalService.Close(this);
    }

    public static implicit operator ModalInstance(ModalInstance<TResponse> instance)
        => new(instance._modalService, instance.ModalType, instance.Parameters);
}

public class ModalInstance : ModalInstance<EmptyResult>
{
    public ModalInstance(IModalService modalService, Type modalType, IDictionary<string, object?> parameters) : base(modalService, modalType, parameters)
    {
    }

    public void Close()
    {
        Close(default);
    }
}
