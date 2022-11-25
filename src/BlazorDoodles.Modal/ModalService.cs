using Microsoft.AspNetCore.Components;

namespace BlazorDoodles.Modal;

public class ModalService : IModalService
{
    private readonly List<IModalReference> _activeModals = new();
    public IReadOnlyCollection<IModalReference> ActiveModals => _activeModals.AsReadOnly();

    public Action? OnChange { get; set; }

    public async Task<IModalResult> Open<TModal>() where TModal : IComponent 
        => await OpenModal(new ModalInstance<TModal>(this));

    public async Task<IModalResult> Open<TModal>(IModalParameters<TModal, EmptyResult> parameters) where TModal : IComponent
        => await OpenModal(new ModalInstance<TModal>(this, parameters.ToDictionary()));

    public Task<IModalResult<TResponse>> Open<TModal, TResponse>() where TModal : IComponent
        => OpenModal(new ModalInstance<TModal, TResponse>(this));

    public Task<IModalResult<TResponse>> Open<TModal, TResponse>(IModalParameters<TModal, TResponse> parameters) where TModal : IComponent
        => OpenModal(new ModalInstance<TModal, TResponse>(this, parameters.ToDictionary()));

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

    private Task<IModalResult<TResponse>> OpenModal<TResponse>(IModalInstance<TResponse> modal)
    {
        AddModal(modal);
        return modal.Result;
    }
}
