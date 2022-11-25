namespace BlazorDoodles.Modal;

public interface IModalReference
{
    Type ModalType { get; }
    IDictionary<string, object?> Parameters { get; }

    void Cancel();
}

public interface IModalInstance : IModalReference
{
    Task<IModalResult> Result { get; }
    void Close();
}

public interface IModalInstance<TResponse> : IModalReference
{
    Task<IModalResult<TResponse>> Result { get; }
    void Close(TResponse response);
}
