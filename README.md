<img src="https://raw.githubusercontent.com/dwndland/Chapter.Net.BLZ/master/Icon.png" alt="logo" width="64"/>

# Chapter.Net.BLZ Library

## Overview
Chapter.Net.BLZ provides features for an easy work with MVVM for blazor applications.

## Features
- **ViewModelComponent:** A component for an easy connecting of viewmodels to a UI component.

## Getting Started

1. **Installation:**
    - Install the Chapter.Net.BLZ library via NuGet Package Manager:
    ```bash
    dotnet add package Chapter.Net.BLZ
    ```

2. **Connect a razor page to its viewmodel**
    ```razor
    @inherits ViewModelComponent<SetupViewModel>

    <FluentButton OnClick="DataContext.Save">Save</FluentButton>
    ```
    ```csharp
    builder.Services.AddTransient<SetupViewModel>();
    ```
    ```csharp
    public class SetupViewModel : ObservableObject, IViewModel
    {
        public void Save()
        {
        }
    }
    ```

## Links
* [NuGet](https://www.nuget.org/packages/Chapter.Net.BLZ)
* [GitHub](https://github.com/dwndland/Chapter.Net.BLZ)

## License
Copyright (c) David Wendland. All rights reserved.
Licensed under the MIT License. See LICENSE file in the project root for full license information.
