using Microsoft.Extensions.DependencyInjection;

// ReSharper disable once CheckNamespace
namespace Yarp.EfCore.Configuration;

public static class ReverseProxyBuilderExtensions
{
    public static IReverseProxyBuilder LoadFromPostgreSql(this IReverseProxyBuilder builder, Action<dynamic> unknown)
    {
        
        return builder;
    }
}