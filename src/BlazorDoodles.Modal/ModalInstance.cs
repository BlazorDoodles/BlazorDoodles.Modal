namespace BlazorDoodles.Modal;

public class ModalInstance<TModal, TResponse> : IModalInstance<TResponse>
{
    protected readonly IModalService _modalService;
    private readonly TaskCompletionSource<IModalResult<TResponse>> _resultCompletion;

    public Type ModalType => typeof(TModal);
    public IDictionary<string, object?> Parameters { get; }

    public Task<IModalResult<TResponse>> Result => _resultCompletion.Task;

    internal ModalInstance(IModalService modalService, IDictionary<string, object?> parameters)
    {
        _modalService = modalService;
        _resultCompletion = new(TaskCreationOptions.RunContinuationsAsynchronously);

        Parameters = parameters;
        Parameters.Add(nameof(ModalBase.Modal), this);
    }

    internal ModalInstance(IModalService modalService) : this(modalService, new Dictionary<string, object?>())
    {
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
}

public class ModalInstance<TModal> : ModalInstance<TModal, EmptyResult>, IModalInstance
{
    private readonly TaskCompletionSource<IModalResult> _resultCompletion;

    internal ModalInstance(IModalService modalService, IDictionary<string, object?> parameters) : base(modalService, parameters)
    {
        _resultCompletion = new(TaskCreationOptions.RunContinuationsAsynchronously);
    }

    internal ModalInstance(IModalService modalService) : this(modalService, new Dictionary<string, object?>())
    {
    }

    Task<IModalResult> IModalInstance.Result => _resultCompletion.Task;

    public void Close()
    {
        Close(default);
    }
}
