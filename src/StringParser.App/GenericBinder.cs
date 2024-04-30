using Microsoft.Extensions.DependencyInjection;
using System.CommandLine.Binding;

namespace StringParser;

internal class GenericBinder<T> : BinderBase<T>
{
    private readonly IServiceProvider _serviceProvider;

    public GenericBinder(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected override T GetBoundValue(BindingContext bindingContext) => GetService();

    private T GetService()
    {
        if (_serviceProvider.GetRequiredService(typeof(T)) is T service)
            return service;

        throw new Exception("DI Error");
    }
}
