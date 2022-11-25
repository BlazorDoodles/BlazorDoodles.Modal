using Microsoft.AspNetCore.Components;

namespace BlazorDoodles.Modal;

public interface IModalParameters<TModal, TResponse> where TModal : IComponent
{
    IDictionary<string, object?> ToDictionary();
}
