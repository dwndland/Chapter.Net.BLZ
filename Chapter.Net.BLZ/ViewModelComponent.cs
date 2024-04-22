// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ViewModelComponent.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.ComponentModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Chapter.Net.BLZ;

/// <summary>
/// Base class for razor components which support the MVVM pattern.
/// </summary>
/// <typeparam name="TViewModel">The ViewModel type.</typeparam>
public class ViewModelComponent<TViewModel> : ComponentBase
{
    [Inject]
    public TViewModel DataContext { get; set; }

    protected override Task OnInitializedAsync()
    {
        if (DataContext is INotifyPropertyChanged propertyChanged)
            propertyChanged.PropertyChanged += async (_, _) => await InvokeAsync(StateHasChanged);

        return base.OnInitializedAsync();
    }
}