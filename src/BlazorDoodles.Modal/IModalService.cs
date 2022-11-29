using Microsoft.AspNetCore.Components;

namespace BlazorDoodles.Modal;

public interface IModalService
{
    IReadOnlyCollection<IModalReference> ActiveModals { get; }
    Action? OnChange { get; set; }

    Task<IModalResult> Open<TModal>() where TModal : ModalBase;
    Task<IModalResult> Open<TModal>(IModalParameters<TModal, EmptyResult> parameters) where TModal : ModalBase;
    Task<IModalResult<TResponse>> Open<TModal, TResponse>() where TModal : ModalBase<TResponse>;
    Task<IModalResult<TResponse>> Open<TModal, TResponse>(IModalParameters<TModal, TResponse> parameters) where TModal : ModalBase<TResponse>;
    
    void Close(IModalReference modal);
}
