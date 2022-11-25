﻿using Microsoft.AspNetCore.Components;

namespace BlazorDoodles.Modal;

public interface IModalService
{
    IReadOnlyCollection<IModalReference> ActiveModals { get; }
    Action? OnChange { get; set; }

    Task<IModalResult> Open<TModal>() where TModal : IComponent;
    Task<IModalResult> Open<TModal>(IModalParameters<TModal, EmptyResult> parameters) where TModal : IComponent;
    Task<IModalResult<TResponse>> Open<TModal, TResponse>() where TModal : IComponent;
    Task<IModalResult<TResponse>> Open<TModal, TResponse>(IModalParameters<TModal, TResponse> parameters) where TModal : IComponent;
    
    void Close(IModalReference modal);
}
