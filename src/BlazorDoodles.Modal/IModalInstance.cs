namespace BlazorDoodles.Modal;

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
