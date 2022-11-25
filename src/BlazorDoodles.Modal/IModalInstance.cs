namespace BlazorDoodles.Modal;

public interface IModalInstance : IModalReference
{
    Task<IModalResult> Result { get; }

    void Cancel();
    void Close();
}

public interface IModalInstance<TResponse> : IModalReference
{
    Task<IModalResult<TResponse>> Result { get; }

    void Cancel();
    void Close(TResponse response);
}
