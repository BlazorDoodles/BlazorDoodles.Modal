# BlazorDoodles.Modal

A Blazor modal framework without any opinions about styling.

## Setup

Add the following to your Blazor project to get started:

#### Program.cs
```csharp
builder.Services.AddModalDoodle();
```

#### _Imports.razor

```csharp
@using BlazorDoodles.Modal
```

#### App.razor
```html
<Router AppAssembly="@typeof(App).Assembly">
    <Found Context="routeData">
        <RouteView RouteData="@routeData" DefaultLayout="@typeof(MainLayout)" />
        <FocusOnNavigate RouteData="@routeData" Selector="h1" />
    </Found>
    <NotFound>
        <PageTitle>Not found</PageTitle>
        <LayoutView Layout="@typeof(MainLayout)">
            <p role="alert">Sorry, there's nothing at this address.</p>
        </LayoutView>
    </NotFound>
</Router>

<!-- Add this! -->
<ModalDisplay />
```

## Example Usage

Check out the [sample](samples/SampleApp) project for a more complete picture of usage.

### Basic Modal
To use a basic modal, simply add `@inherits ModalBase` to your modal component:

#### SimpleModal.razor
```html
@inherits ModalBase

<!-- Replace with your modal markup! -->
<MyModal>
    <div class="modal-header">
        <h1 class="modal-title fs-5">@Title</h1>
        <button @onclick="Modal.Cancel" type="button" class="btn-close" aria-label="Close"></button>
    </div>
    <div class="modal-body">
        @Text
    </div>
    
    <!-- Note the click events on the buttons! -->
    <div class="modal-footer">
        <div class="col">
            <button @onclick="Modal.Close" type="button" class="btn btn-primary w-100">
                Confirm
            </button>
        </div>
        <div class="col">
            <button @onclick="Modal.Cancel" type="button" class="btn btn-secondary w-100">
                Cancel
            </button>
        </div>
    </div>
</MyModal>


```

To launch this modal, use `IModalService`:
#### SimpleModalDemo.razor
```csharp
@inject IModalService ModalService

@code {
    private IModalResult? Result { get; set; }

    private async Task ShowModal()
    {
        Result = await ModalService.Open<SimpleModal>();
    }
}
```

### Returning data
To enable a modal to return custom data, inherit from `ModalBase<T>`.

#### FormModal.razor
```html
@inherits ModalBase<PersonModel>

<EditForm Model="NewPerson" OnValidSubmit="() => Modal.Close(NewPerson)">    
    <DataAnnotationsValidator />    
    <!-- Some form inputs, etc. -->
</EditForm>

@code {
    private PersonModel NewPerson { get; set; } = new();
}
```

Now when you launch the modal you'll get back a typed response:

#### FormModalDemo.razor
```csharp
@inject IModalService ModalService

@code {
    private List<PersonModel> People { get; set; } = new();

    private IModalResult<PersonModel>? Result { get; set; }

    private async Task ShowModal()
    {
        Result = await ModalService.Open<FormModal, PersonModel>();

        if (!Result.IsCanceled)
            People.Add(Result.Data);
    }
}
```

### Passing parameters
To pass data to a modal, define a class to hold parameter data. You can use validation here too.

#### ConfirmationModal.razor
```csharp
@inherits ModalBase

@code {

    [Parameter, EditorRequired] public string Title { get; set; } = default!;
    [Parameter, EditorRequired] public string Text { get; set; } = default!;

    public class Parameters : ModalParameters<ConfirmationModal>
    {
        [Required] public string Title { get; set; } = "Confirm Action";
        [Required] public string Text { get; set; } = "Are you sure you want to do this?";
    }
}
```

To launch this modal:

#### ConfirmationModalDemo.razor
```csharp
@inject IModalService ModalService

@code {
    private ConfirmationModal.Parameters Parameters { get; set; } = new();
    private IModalResult? Result { get; set; }

    private async Task ShowConfirmationModal()
    {
        Result = await ModalService.Open<ConfirmationModal>(Parameters);
    }
}
```
