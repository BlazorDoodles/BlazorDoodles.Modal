namespace BlazorDoodles.Modal;

public interface IModalResult
{
    bool IsCanceled { get; }
}

public interface IModalResult<TResponse> : IModalResult
{
    TResponse Data { get; }
    TResponse? DataOrDefault { get; }
}
