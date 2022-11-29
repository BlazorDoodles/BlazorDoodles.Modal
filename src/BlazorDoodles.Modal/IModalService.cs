namespace BlazorDoodles.Modal;

public interface IModalService
{
    IReadOnlyCollection<IModalReference> ActiveModals { get; }
    Action? OnChange { get; set; }

    Task<IModalResult> Open<TModal>() 
        where TModal : ModalBase;

    Task<IModalResult> Open<TModal, TParameters>(TParameters parameters)
        where TModal : ModalBase
        where TParameters : IModalParameters<TModal, EmptyResult>;

    Task<IModalResult<TResponse>> Open<TModal, TResponse>()
        where TModal : ModalBase<TResponse>;

    Task<IModalResult<TResponse>> Open<TModal, TResponse, TParameters>(TParameters parameters)
        where TModal : ModalBase<TResponse>
        where TParameters : IModalParameters<TModal, TResponse>;

    void Close(IModalReference modal);
}
