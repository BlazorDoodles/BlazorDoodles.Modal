namespace BlazorDoodles.Modal;

public interface IModalReference
{
    Type ModalType { get; }
    IDictionary<string, object?> Parameters { get; }
}
