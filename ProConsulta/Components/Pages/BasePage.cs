using Microsoft.AspNetCore.Components;

using MudBlazor;

namespace ProConsulta.Components.Pages;

public class BasePage : ComponentBase
{
    [Inject]
    public IDialogService DialogService { get; set; } = null!;
    [Inject]
    public ISnackbar Snackbar { get; set; } = null!;
    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;
}