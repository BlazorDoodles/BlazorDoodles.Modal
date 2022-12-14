namespace BlazorDoodles.Modal;

public class ModalResult<TResponse> : IModalResult<TResponse>
{
    public bool IsCanceled { get; }
    public TResponse Data => DataOrDefault!;
    public TResponse? DataOrDefault { get; }

    public ModalResult(bool isCanceled, TResponse? data)
    {
        IsCanceled = isCanceled;
        DataOrDefault = data;
    }

    public static ModalResult<TResponse> Cancel() => new(true, default);
    public static ModalResult<TResponse> Ok(TResponse data) => new(false, data);

    public static implicit operator ModalResult(ModalResult<TResponse> result) => new(result.IsCanceled);
}

public class ModalResult : ModalResult<EmptyResult>, IModalResult
{
    public ModalResult(bool isCanceled) : base(isCanceled, default)
    {
    }

    public static ModalResult<TResponse> Cancel<TResponse>() => new(true, default);
    public static ModalResult<TResponse> Ok<TResponse>(TResponse data) => new(false, data);
}
