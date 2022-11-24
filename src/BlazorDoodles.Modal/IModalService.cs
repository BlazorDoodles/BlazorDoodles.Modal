namespace BlazorDoodles.Modal;

public interface IModalService
{
    IReadOnlyCollection<IModalInstance> ActiveModals { get; }
    Action? OnChange { get; set; }

    Task<ModalResult> Open<TModal>() where TModal : IModal;
    Task<ModalResult> Open<TModal>(IModalParameters<TModal> request) where TModal : IModal;
    Task<ModalResult<TResponse>> Open<TModal, TResponse>() where TModal : IModal;
    Task<ModalResult<TResponse>> Open<TModal, TResponse>(IModalParameters<TModal, TResponse> request) where TModal : IModal;
    
    void Close(IModalInstance modal);

    internal Task<ModalResult<TResponse>> Open<TResponse>(ModalInstance<TResponse> modal);
}
