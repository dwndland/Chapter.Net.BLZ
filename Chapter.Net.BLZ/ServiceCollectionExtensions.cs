// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceCollectionExtensions.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Chapter.Net.BLZ;

/// <summary>
///     Extends the IServiceCollection.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    ///     Automatically registers all IViewModels into the services as transients.
    /// </summary>
    /// <param name="serviceCollection"></param>
    /// <param name="assemblies"></param>
    public static void AddAutoViewModels(this IServiceCollection serviceCollection, params Assembly[] assemblies)
    {
        foreach (var assembly in assemblies)
        {
            var viewModelTypes = assembly.GetTypes()
                .Where(t => typeof(IViewModel).IsAssignableFrom(t) && t.IsClass && !t.IsAbstract);

            foreach (var viewModelType in viewModelTypes)
                serviceCollection.AddTransient(viewModelType);
        }
    }
}