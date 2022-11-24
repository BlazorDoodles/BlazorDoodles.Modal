using Microsoft.AspNetCore.Components;

namespace BlazorDoodles.Modal;

public abstract class ModalBase : ComponentBase, IModal<ModalInstance>
{
    [Parameter] public ModalInstance Modal { get; set; } = null!;
}

public abstract class ModalBase<TResponse> : ComponentBase, IModal<ModalInstance<TResponse>>
{
    [Parameter] public ModalInstance<TResponse> Modal { get; set; } = null!;
}
