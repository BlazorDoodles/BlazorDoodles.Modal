using BlazorDoodles.Modal;
using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;

namespace SampleApp.Shared;

public class ConfirmationModalParameters : ModalParameters<ConfirmationModal>
{
    [Required]
    public string Title { get; set; } = "Confirm Action";

    [Required]
    public string Text { get; set; } = "Are you sure you want to do this?";
}

public partial class ConfirmationModal
{
    [Parameter, EditorRequired] public string Title { get; set; } = default!;
    [Parameter, EditorRequired] public string Text { get; set; } = default!;
}
