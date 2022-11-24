using Microsoft.AspNetCore.Components;

namespace BlazorDoodles.Modal;

public interface IModal<T> : IModal where T : IModalInstance
{
    T Modal { get; }
}

public interface IModal : IComponent
{
}