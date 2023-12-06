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
    public DbSet<TransformConfigEntity> TransformConfigs { get; set; } = null!;
    public DbSet<TransformEntity> Transforms { get; set; } = null!;
    public DbSet<RouteHeaderEntity> RouteHeaders { get; set; } = null!;
    public DbSet<RouteMatchEntity> RouteMatches { get; set; } = null!;
    public DbSet<RouteQueryParameterEntity> RouteQueryParameters { get; set; } = null!;
    public DbSet<SessionAffinityConfigEntity> SessionAffinityConfigs { get; set; } = null!;
    public DbSet<SessionAffinityCookieConfigEntity> SessionAffinityCookieConfigs { get; set; } = null!;
    public DbSet<WebProxyConfigEntity> WebProxyConfigs { get; set; } = null!;
    public DbSet<ProxyConfigEntity> ProxyConfigs { get; set; } = null!;
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ClusterConfigEntity>()
            .Navigation(e => e.Metadata).AutoInclude();
        modelBuilder.Entity<ClusterConfigEntity>()
            .Navigation(e => e.Destinations).AutoInclude();
        modelBuilder.Entity<ClusterConfigEntity>()
            .Navigation(e => e.HealthCheck).AutoInclude();
        modelBuilder.Entity<ClusterConfigEntity>()
            .Navigation(e => e.HttpClient).AutoInclude();
        modelBuilder.Entity<ClusterConfigEntity>()
            .Navigation(e => e.HttpRequest).AutoInclude();
        modelBuilder.Entity<ClusterConfigEntity>()
            .Navigation(e => e.SessionAffinity).AutoInclude();
        modelBuilder.Entity<RouteConfigEntity>()
            .Navigation(e => e.Metadata).AutoInclude();
        modelBuilder.Entity<RouteConfigEntity>()
            .Navigation(e => e.Transforms).AutoInclude();
        modelBuilder.Entity<RouteConfigEntity>()
            .Navigation(e => e.Match).AutoInclude();
        modelBuilder.Entity<TransformEntity>()
            .Navigation(e => e.TransformConfigs).AutoInclude();
        modelBuilder.Entity<ClusterConfigDestinationEntity>()
            .Navigation(e => e.DestinationConfig).AutoInclude();
        
        modelBuilder.Entity<ClusterConfigDestinationEntity>()
            .Navigation(e => e.ClusterConfig).AutoInclude();
        
        modelBuilder.Entity<DestinationConfigEntity>()
            .Navigation(e => e.Metadata).AutoInclude();
        
        modelBuilder.Entity<HealthCheckConfigEntity>()
            .Navigation(e => e.Passive).AutoInclude();
        modelBuilder.Entity<HealthCheckConfigEntity>()
            .Navigation(e => e.Active).AutoInclude();
        modelBuilder.Entity<HttpClientConfigEntity>()
            .Navigation(e => e.WebProxy).AutoInclude();
        modelBuilder.Entity<RouteMatchEntity>()
            .Navigation(e => e.Headers).AutoInclude();
        modelBuilder.Entity<RouteMatchEntity>()
            .Navigation(e => e.QueryParameters).AutoInclude();
        modelBuilder.Entity<SessionAffinityConfigEntity>()
            .Navigation(e => e.Cookie).AutoInclude();
        modelBuilder.Entity<TransformEntity>()
            .Navigation(e => e.RouteConfig).AutoInclude();
        modelBuilder.Entity<ProxyConfigEntity>()
            .Navigation(e => e.RouteConfig).AutoInclude();

        modelBuilder.Entity<ProxyConfigEntity>()
            .HasIndex(p => new {p.Name, p.RouteConfigId}).IsUnique();
    }
}