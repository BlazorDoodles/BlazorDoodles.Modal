using Microsoft.AspNetCore.Components;

namespace BlazorDoodles.Modal;

public abstract class ModalBase : ComponentBase
{
    [Parameter] public IModalInstance Modal { get; set; } = null!;
}

public abstract class ModalBase<TResponse> : ComponentBase
{
    [Parameter] public IModalInstance<TResponse> Modal { get; set; } = null!;
}
