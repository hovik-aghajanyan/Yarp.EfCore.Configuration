using Microsoft.Extensions.Primitives;
using Yarp.ReverseProxy.Configuration;

namespace Yarp.EfCore.Configuration.Configurations;

public class EfCoreConfig:IProxyConfig
{
    private readonly CancellationTokenSource _cts = new();
    
    
    public IReadOnlyList<RouteConfig> Routes { get; }
    public IReadOnlyList<ClusterConfig> Clusters { get; }
    public IChangeToken ChangeToken { get; }

    public EfCoreConfig(IReadOnlyList<RouteConfig> routes, IReadOnlyList<ClusterConfig> clusters)
        : this(routes, clusters, Guid.NewGuid().ToString())
    {
    }
    
    public EfCoreConfig(IReadOnlyList<RouteConfig> routes, IReadOnlyList<ClusterConfig> clusters, string revisionId)
    {
        RevisionId = revisionId ?? throw new ArgumentNullException(nameof(revisionId));
        Routes = routes;
        Clusters = clusters;
        ChangeToken = new CancellationChangeToken(_cts.Token);
    }

    internal void SignalChange() => this._cts.Cancel();
    
    /// <inheritdoc/>
    public string RevisionId { get; }


}