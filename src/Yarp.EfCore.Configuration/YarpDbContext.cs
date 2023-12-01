using Microsoft.EntityFrameworkCore;
using Yarp.EfCore.Configuration.Entities;

namespace Yarp.EfCore.Configuration;

public class YarpDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<ActiveHealthCheckConfigEntity> ActiveHealthCheckConfigs { get; set; } = null!;
    public DbSet<ClusterConfigEntity> ClusterConfigs { get; set; } = null!;
    public DbSet<ClusterConfigDestinationEntity> ClusterConfigsDestinations { get; set; } = null!;
    public DbSet<ClusterConfigMetadataEntity> ClusterConfigsMetadata { get; set; } = null!;
    public DbSet<DestinationConfigEntity> DestinationConfigs { get; set; } = null!;
    public DbSet<DestinationConfigMetadataEntity> DestinationConfigMetadata { get; set; } = null!;
    public DbSet<ForwarderRequestConfigEntity> ForwarderRequestConfigs { get; set; } = null!;
    public DbSet<HealthCheckConfigEntity> HealthCheckConfigs { get; set; } = null!;
    public DbSet<HttpClientConfigEntity> HttpClientConfigs { get; set; } = null!;
    public DbSet<PassiveHealthCheckConfigEntity> PassiveHealthCheckConfigs { get; set; } = null!;
    public DbSet<RouteConfigEntity> RouteConfigs { get; set; } = null!;
    public DbSet<RouteConfigMetadataEntity> RouteConfigMetadata { get; set; } = null!;
    public DbSet<TransformEntity> Transforms { get; set; } = null!;
    public DbSet<TransformConfigEntity> TransformConfigs { get; set; } = null!;
    public DbSet<RouteHeaderEntity> RouteHeaders { get; set; } = null!;
    public DbSet<RouteMatchEntity> RouteMatches { get; set; } = null!;
    public DbSet<RouteQueryParameterEntity> RouteQueryParameters { get; set; } = null!;
    public DbSet<SessionAffinityConfigEntity> SessionAffinityConfigs { get; set; } = null!;
    public DbSet<SessionAffinityCookieConfigEntity> SessionAffinityCookieConfigs { get; set; } = null!;
    public DbSet<WebProxyConfigEntity> WebProxyConfigs { get; set; } = null!;

}