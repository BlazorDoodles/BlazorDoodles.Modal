using Microsoft.AspNetCore.Components;

namespace BlazorDoodles.Modal;

public interface IModalParameters<TModal, TResponse> where TModal : IComponent
{
    IDictionary<string, object?> ToDictionary();
}

public interface IModalParameters<TModal> : IModalParameters<TModal, EmptyResult> where TModal : IComponent
{
}
