namespace BlazorDoodles.Modal;

public interface IModalService
{
    IReadOnlyCollection<IModalInstance> ActiveModals { get; }
    Action? OnChange { get; set; }

    Task<IModalResult> Open<TModal>() where TModal : IModal;
    Task<IModalResult> Open<TModal>(IModalParameters<TModal> request) where TModal : IModal;
    Task<IModalResult<TResponse>> Open<TModal, TResponse>() where TModal : IModal;
    Task<IModalResult<TResponse>> Open<TModal, TResponse>(IModalParameters<TModal, TResponse> request) where TModal : IModal;
    
    void Close(IModalInstance modal);
}
