using Microsoft.AspNetCore.Components;

namespace BlazorDoodles.Modal;

public abstract class ModalBase : ComponentBase
{
    [Parameter] public ModalInstance Modal { get; set; } = null!;
}

public abstract class ModalBase<TResponse> : ComponentBase
{
    [Parameter] public ModalInstance<TResponse> Modal { get; set; } = null!;
}
