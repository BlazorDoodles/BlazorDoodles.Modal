using Microsoft.AspNetCore.Components;

namespace BlazorDoodles.Modal;

public abstract class ModalParameters<TModal, TResponse> : IModalParameters<TModal, TResponse> where TModal : IComponent
{
    public virtual IDictionary<string, object?> ToDictionary()
    {
        var parameters = new Dictionary<string, object?>();

        foreach (var property in GetType().GetProperties())
            parameters.Add(property.Name, property.GetValue(this));

        return parameters;
    }
}

public abstract class ModalParameters<TModal> : ModalParameters<TModal, EmptyResult> where TModal : IComponent
{
}
