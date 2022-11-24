namespace BlazorDoodles.Modal;

public interface IModalService
{
    IReadOnlyCollection<IModalInstance> ActiveModals { get; }
    Action? OnChange { get; set; }

    Task<ModalResult<TResponse>> Open<TModal, TResponse>() where TModal : ModalBase<TResponse>;
    Task<ModalResult<TResponse>> Open<TModal, TResponse>(IModalParameters<TModal, TResponse> request) where TModal : ModalBase<TResponse>;
    void Close(IModalInstance modal);
    Task<ModalResult> Open<TModal>() where TModal : ModalBase;
    Task<ModalResult> Open<TModal>(IModalParameters<TModal> request) where TModal : ModalBase;
}

public class ModalService : IModalService
{
    private readonly List<IModalInstance> _activeModals = new();
    public IReadOnlyCollection<IModalInstance> ActiveModals => _activeModals.AsReadOnly();

    public Action? OnChange { get; set; }
    
    public Task<ModalResult<TResponse>> Open<TModal, TResponse>()
        where TModal : ModalBase<TResponse>
    {
        var modal = new ModalInstance<TResponse>(this, typeof(TModal), new Dictionary<string, object?>());
        AddModal(modal);
        return modal.Result;
    }

    public Task<ModalResult<TResponse>> Open<TModal, TResponse>(IModalParameters<TModal, TResponse> request)
        where TModal : ModalBase<TResponse>
    {
        var modal = new ModalInstance<TResponse>(this, typeof(TModal), request.ToDictionary());
        AddModal(modal);
        return modal.Result;
    }

    public async Task<ModalResult> Open<TModal>() where TModal : ModalBase
    {
        var modal = new ModalInstance(this, typeof(TModal), new Dictionary<string, object?>());
        AddModal(modal);
        return await modal.Result;
    }

    public async Task<ModalResult> Open<TModal>(IModalParameters<TModal> request) where TModal : ModalBase
    {
        var modal = new ModalInstance(this, typeof(TModal), request.ToDictionary());
        AddModal(modal);
        return await modal.Result;
    }

    public void Close(IModalInstance modal)
    {
        RemoveModal(modal);
    }

    private void AddModal(IModalInstance modal)
    {
        _activeModals.Add(modal);
        OnChange?.Invoke();
    }

    private void RemoveModal(IModalInstance modal)
    {
        _activeModals.Remove(modal);
        OnChange?.Invoke();
    }
}
