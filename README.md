![Chapter](https://raw.githubusercontent.com/dwndland/Chapter.Net.BLZ/master/Icon.png)

# Chapter.Net.BLZ Library

## Overview
Chapter.Net.BLZ provides features for an easy work with MVVM for blazor applications.

## Features
- **ViewModelComponent:** A component for an easy connecting of viewmodels to a UI component.
- **AddAutoViewModels:** Automatically registers all IViewModels to the IOC.

## Getting Started

1. **Installation:**
    - Install the Chapter.Net.BLZ library via NuGet Package Manager:
    ```bash
    dotnet add package Chapter.Net.BLZ
    ```

2. **ViewModelComponent (Connect a razor page to its viewmodel)**
    ```razor
    @inherits ViewModelComponent<SetupViewModel>

    <div class="input-group">
        <FluentTextField Class="inputField" @bind-Value="@DataContext.Directory"></FluentTextField>
        <FluentButton OnClick="DataContext.Browse">Browse...</FluentButton>
    </div>
    ```
    ```csharp
    builder.Services.AddTransient<SetupViewModel>();
    ```
    ```csharp
    public class SetupViewModel : ObservableObject, IViewModel
    {
        public string Directory;

        public void Browse()
        {
            Directory = "DemoDirectory";
            // NotifyAndSetIfChanged(ref Directory, "DemoDirectory");
            // NotifyPropertyChanged(nameof(Directory));
        }
    }
    ```

3. **AddAutoViewModels (Automatically registers all IViewModels to the IOC)**
    ```csharp
    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddAutoViewModels(Assembly.GetExecutingAssembly());
    builder.Services.AddAutoViewModels(ExtraAssembliesProvider.Assemblies);
    ```
    ```csharp
    public partial class SetupView : ComponentBase
    {
        [Inject]
        public SetupViewModel DataContext { get; set; }
    }
    ```
    ```csharp
    public class SetupViewModel : ObservableObject, IViewModel
    {
    }
    ```

## Links
* [NuGet](https://www.nuget.org/packages/Chapter.Net.BLZ)
* [GitHub](https://github.com/dwndland/Chapter.Net.BLZ)

## License
Copyright (c) David Wendland. All rights reserved.
Licensed under the MIT License. See LICENSE file in the project root for full license information.
