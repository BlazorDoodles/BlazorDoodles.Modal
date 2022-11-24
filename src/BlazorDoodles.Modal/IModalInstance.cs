namespace BlazorDoodles.Modal;

public interface IModalInstance
{
    Type ModalType { get; }
    IDictionary<string, object?> Parameters { get; }
}
