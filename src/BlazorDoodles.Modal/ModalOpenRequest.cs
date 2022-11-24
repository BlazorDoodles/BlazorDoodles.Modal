namespace BlazorDoodles.Modal;

public interface IModalParameters<TModal> where TModal : ModalBase
{
    IDictionary<string, object?> ToDictionary();
}

public interface IModalParameters<TModal, TResponse>
    where TModal : ModalBase<TResponse>
{
    IDictionary<string, object?> ToDictionary();
}

public abstract class ModalParameters
{
    public virtual IDictionary<string, object?> ToDictionary()
    {
        var parameters = new Dictionary<string, object?>();

        foreach (var property in GetType().GetProperties())
            parameters.Add(property.Name, property.GetValue(this));

        return parameters;
    }
}

public abstract class ModalParameters<TModal> : ModalParameters, IModalParameters<TModal> 
    where TModal : ModalBase
{
}

public abstract class ModalParameters<TModal, TResponse> : ModalParameters, IModalParameters<TModal, TResponse>
    where TModal : ModalBase<TResponse>
{
}
