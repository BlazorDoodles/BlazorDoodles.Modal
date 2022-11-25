using Microsoft.AspNetCore.Components;

namespace BlazorDoodles.Modal;

public abstract class ModalBase : ComponentBase, IModal
{
    [Parameter] public IModalInstance Modal { get; set; } = null!;
}

public abstract class ModalBase<TResponse> : ComponentBase, IModal
{
    [Parameter] public IModalInstance<TResponse> Modal { get; set; } = null!;
}
