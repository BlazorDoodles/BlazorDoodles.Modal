using Microsoft.AspNetCore.Components;

namespace BlazorDoodles.Modal;

public class ModalService : IModalService
{
    private readonly List<IModalReference> _activeModals = new();
    public IReadOnlyCollection<IModalReference> ActiveModals => _activeModals.AsReadOnly();

    public Action? OnChange { get; set; }

    public async Task<IModalResult> Open<TModal>() where TModal : IComponent 
        => await Open(new ModalInstance(this, typeof(TModal), new Dictionary<string, object?>()));

    public async Task<IModalResult> Open<TModal>(IModalParameters<TModal, EmptyResult> request) where TModal : IComponent
        => await Open(new ModalInstance(this, typeof(TModal), request.ToDictionary()));

    public Task<IModalResult<TResponse>> Open<TModal, TResponse>() where TModal : IComponent
        => Open(new ModalInstance<TResponse>(this, typeof(TModal), new Dictionary<string, object?>()));

    public Task<IModalResult<TResponse>> Open<TModal, TResponse>(IModalParameters<TModal, TResponse> request) where TModal : IComponent
        => Open(new ModalInstance<TResponse>(this, typeof(TModal), request.ToDictionary()));

    public void Close(IModalReference modal) => RemoveModal(modal);

    private void AddModal(IModalReference modal)
    {
        _activeModals.Add(modal);
        OnChange?.Invoke();
    }

    private void RemoveModal(IModalReference modal)
    {
        _activeModals.Remove(modal);
        OnChange?.Invoke();
    }

    public Task<IModalResult<TResponse>> Open<TResponse>(IModalInstance<TResponse> modal)
    {
        AddModal(modal);
        return modal.Result;
    }
}
