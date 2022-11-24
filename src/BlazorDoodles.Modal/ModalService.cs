namespace BlazorDoodles.Modal;

public class ModalService : IModalService
{
    private readonly List<IModalInstance> _activeModals = new();
    public IReadOnlyCollection<IModalInstance> ActiveModals => _activeModals.AsReadOnly();

    public Action? OnChange { get; set; }

    public async Task<ModalResult> Open<TModal>() where TModal : IModal 
        => await Open(new ModalInstance(this, typeof(TModal), new Dictionary<string, object?>()));

    public async Task<ModalResult> Open<TModal>(IModalParameters<TModal> request) where TModal : IModal
        => await Open(new ModalInstance(this, typeof(TModal), request.ToDictionary()));

    public Task<ModalResult<TResponse>> Open<TModal, TResponse>() where TModal : IModal 
        => Open(new ModalInstance<TResponse>(this, typeof(TModal), new Dictionary<string, object?>()));

    public Task<ModalResult<TResponse>> Open<TModal, TResponse>(IModalParameters<TModal, TResponse> request) where TModal : IModal 
        => Open(new ModalInstance<TResponse>(this, typeof(TModal), request.ToDictionary()));

    public void Close(IModalInstance modal)
        => RemoveModal(modal);

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

    public Task<ModalResult<TResponse>> Open<TResponse>(ModalInstance<TResponse> modal)
    {
        AddModal(modal);
        return modal.Result;
    }
}
