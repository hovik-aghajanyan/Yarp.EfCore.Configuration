﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Yarp.EfCore.Configuration.MsSql;

#nullable disable

namespace Yarp.EfCore.Configuration.MsSql.Migrations
{
    [DbContext(typeof(MsSqlYarpDbContext))]
    [Migration("20231207125115_AddedConstrains")]
    partial class AddedConstrains
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Yarp.EfCore.Configuration.Entities.ActiveHealthCheckConfigEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool?>("Enabled")
                        .HasColumnType("bit");

                    b.Property<TimeSpan?>("Interval")
                        .HasColumnType("time");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Policy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan?>("Timeout")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.ToTable("ActiveHealthCheckConfigs");
                });

            modelBuilder.Entity("Yarp.EfCore.Configuration.Entities.ClusterConfigDestinationEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClusterConfigId")
                        .HasColumnType("int");

                    b.Property<int>("DestinationConfigId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClusterConfigId");

                    b.HasIndex("DestinationConfigId");

                    b.ToTable("ClusterConfigsDestinations");
                });

            modelBuilder.Entity("Yarp.EfCore.Configuration.Entities.ClusterConfigEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClusterId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("HealthCheckId")
                        .HasColumnType("int");

                    b.Property<int?>("HttpClientId")
                        .HasColumnType("int");

                    b.Property<int?>("HttpRequestId")
                        .HasColumnType("int");

                    b.Property<string>("LoadBalancingPolicy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SessionAffinityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClusterId")
                        .IsUnique();

                    b.HasIndex("HealthCheckId");

                    b.HasIndex("HttpClientId");

                    b.HasIndex("HttpRequestId");

                    b.HasIndex("SessionAffinityId");

                    b.ToTable("ClusterConfigs");
                });

            modelBuilder.Entity("Yarp.EfCore.Configuration.Entities.ClusterConfigMetadataEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ClusterConfigEntityId")
                        .HasColumnType("int");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClusterConfigEntityId");

                    b.ToTable("ClusterConfigsMetadata");
                });

            modelBuilder.Entity("Yarp.EfCore.Configuration.Entities.DestinationConfigEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Health")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Host")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DestinationConfigs");
                });

            modelBuilder.Entity("Yarp.EfCore.Configuration.Entities.DestinationConfigMetadataEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("DestinationConfigEntityId")
                        .HasColumnType("int");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DestinationConfigEntityId");

                    b.ToTable("DestinationConfigMetadata");
                });

            modelBuilder.Entity("Yarp.EfCore.Configuration.Entities.ForwarderRequestConfigEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<TimeSpan?>("ActivityTimeout")
                        .HasColumnType("time");

                    b.Property<bool?>("AllowResponseBuffering")
                        .HasColumnType("bit");

                    b.Property<string>("Version")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("VersionPolicy")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ForwarderRequestConfigs");
                });

            modelBuilder.Entity("Yarp.EfCore.Configuration.Entities.HealthCheckConfigEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ActiveId")
                        .HasColumnType("int");

                    b.Property<string>("AvailableDestinationsPolicy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PassiveId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ActiveId");

                    b.HasIndex("PassiveId");

                    b.ToTable("HealthCheckConfigs");
                });

            modelBuilder.Entity("Yarp.EfCore.Configuration.Entities.HttpClientConfigEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool?>("DangerousAcceptAnyServerCertificate")
                        .HasColumnType("bit");

                    b.Property<bool?>("EnableMultipleHttp2Connections")
                        .HasColumnType("bit");

                    b.Property<int?>("MaxConnectionsPerServer")
                        .HasColumnType("int");

                    b.Property<string>("RequestHeaderEncoding")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SslProtocols")
                        .HasColumnType("int");

                    b.Property<int?>("WebProxyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WebProxyId");

                    b.ToTable("HttpClientConfigs");
                });

            modelBuilder.Entity("Yarp.EfCore.Configuration.Entities.PassiveHealthCheckConfigEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool?>("Enabled")
                        .HasColumnType("bit");

                    b.Property<string>("Policy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan?>("ReactivationPeriod")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.ToTable("PassiveHealthCheckConfigs");
                });

            modelBuilder.Entity("Yarp.EfCore.Configuration.Entities.ProxyConfigEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("RouteConfigId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RouteConfigId");

                    b.HasIndex("Name", "RouteConfigId")
                        .IsUnique();

                    b.ToTable("ProxyConfigs");
                });

            modelBuilder.Entity("Yarp.EfCore.Configuration.Entities.RouteConfigEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AuthorizationPolicy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClusterId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CorsPolicy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit");

                    b.Property<int>("MatchId")
                        .HasColumnType("int");

                    b.Property<long?>("MaxRequestBodySize")
                        .HasColumnType("bigint");

                    b.Property<int?>("Order")
                        .HasColumnType("int");

                    b.Property<string>("RateLimiterPolicy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RouteId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<TimeSpan?>("Timeout")
                        .HasColumnType("time");

                    b.Property<string>("TimeoutPolicy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MatchId");

                    b.HasIndex("RouteId")
                        .IsUnique();

                    b.ToTable("RouteConfigs");
                });

            modelBuilder.Entity("Yarp.EfCore.Configuration.Entities.RouteConfigMetadataEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RouteConfigEntityId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RouteConfigEntityId");

                    b.ToTable("RouteConfigMetadata");
                });

            modelBuilder.Entity("Yarp.EfCore.Configuration.Entities.RouteHeaderEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsCaseSensitive")
                        .HasColumnType("bit");

                    b.Property<int>("Mode")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RouteMatchEntityId")
                        .HasColumnType("int");

                    b.Property<string>("Values")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RouteMatchEntityId");

                    b.ToTable("RouteHeaders");
                });

            modelBuilder.Entity("Yarp.EfCore.Configuration.Entities.RouteMatchEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Hosts")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Methods")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RouteMatches");
                });

            modelBuilder.Entity("Yarp.EfCore.Configuration.Entities.RouteQueryParameterEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsCaseSensitive")
                        .HasColumnType("bit");

                    b.Property<int>("Mode")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RouteMatchEntityId")
                        .HasColumnType("int");

                    b.Property<string>("Values")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RouteMatchEntityId");

                    b.ToTable("RouteQueryParameters");
                });

            modelBuilder.Entity("Yarp.EfCore.Configuration.Entities.SessionAffinityConfigEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AffinityKeyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CookieId")
                        .HasColumnType("int");

                    b.Property<bool?>("Enabled")
                        .HasColumnType("bit");

                    b.Property<string>("FailurePolicy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Policy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CookieId");

                    b.ToTable("SessionAffinityConfigs");
                });

            modelBuilder.Entity("Yarp.EfCore.Configuration.Entities.SessionAffinityCookieConfigEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Domain")
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan?>("Expiration")
                        .HasColumnType("time");

                    b.Property<bool?>("HttpOnly")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsEssential")
                        .HasColumnType("bit");

                    b.Property<TimeSpan?>("MaxAge")
                        .HasColumnType("time");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SameSite")
                        .HasColumnType("int");

                    b.Property<int?>("SecurePolicy")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("SessionAffinityCookieConfigs");
                });

            modelBuilder.Entity("Yarp.EfCore.Configuration.Entities.TransformConfigEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TransformEntityId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TransformEntityId");

                    b.ToTable("TransformConfigs");
                });

            modelBuilder.Entity("Yarp.EfCore.Configuration.Entities.TransformEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("RouteConfigId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RouteConfigId");

                    b.ToTable("Transforms");
                });

            modelBuilder.Entity("Yarp.EfCore.Configuration.Entities.WebProxyConfigEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("BypassOnLocal")
                        .HasColumnType("bit");

                    b.Property<bool?>("UseDefaultCredentials")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("WebProxyConfigs");
                });

            modelBuilder.Entity("Yarp.EfCore.Configuration.Entities.ClusterConfigDestinationEntity", b =>
                {
                    b.HasOne("Yarp.EfCore.Configuration.Entities.ClusterConfigEntity", "ClusterConfig")
                        .WithMany("Destinations")
                        .HasForeignKey("ClusterConfigId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Yarp.EfCore.Configuration.Entities.DestinationConfigEntity", "DestinationConfig")
                        .WithMany()
                        .HasForeignKey("DestinationConfigId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClusterConfig");

                    b.Navigation("DestinationConfig");
                });

            modelBuilder.Entity("Yarp.EfCore.Configuration.Entities.ClusterConfigEntity", b =>
                {
                    b.HasOne("Yarp.EfCore.Configuration.Entities.HealthCheckConfigEntity", "HealthCheck")
                        .WithMany()
                        .HasForeignKey("HealthCheckId");

                    b.HasOne("Yarp.EfCore.Configuration.Entities.HttpClientConfigEntity", "HttpClient")
                        .WithMany()
                        .HasForeignKey("HttpClientId");

                    b.HasOne("Yarp.EfCore.Configuration.Entities.ForwarderRequestConfigEntity", "HttpRequest")
                        .WithMany()
                        .HasForeignKey("HttpRequestId");

                    b.HasOne("Yarp.EfCore.Configuration.Entities.SessionAffinityConfigEntity", "SessionAffinity")
                        .WithMany()
                        .HasForeignKey("SessionAffinityId");

                    b.Navigation("HealthCheck");

                    b.Navigation("HttpClient");

                    b.Navigation("HttpRequest");

                    b.Navigation("SessionAffinity");
                });

            modelBuilder.Entity("Yarp.EfCore.Configuration.Entities.ClusterConfigMetadataEntity", b =>
                {
                    b.HasOne("Yarp.EfCore.Configuration.Entities.ClusterConfigEntity", null)
                        .WithMany("Metadata")
                        .HasForeignKey("ClusterConfigEntityId");
                });

            modelBuilder.Entity("Yarp.EfCore.Configuration.Entities.DestinationConfigMetadataEntity", b =>
                {
                    b.HasOne("Yarp.EfCore.Configuration.Entities.DestinationConfigEntity", null)
                        .WithMany("Metadata")
                        .HasForeignKey("DestinationConfigEntityId");
                });

            modelBuilder.Entity("Yarp.EfCore.Configuration.Entities.HealthCheckConfigEntity", b =>
                {
                    b.HasOne("Yarp.EfCore.Configuration.Entities.ActiveHealthCheckConfigEntity", "Active")
                        .WithMany()
                        .HasForeignKey("ActiveId");

                    b.HasOne("Yarp.EfCore.Configuration.Entities.PassiveHealthCheckConfigEntity", "Passive")
                        .WithMany()
                        .HasForeignKey("PassiveId");

                    b.Navigation("Active");

                    b.Navigation("Passive");
                });

            modelBuilder.Entity("Yarp.EfCore.Configuration.Entities.HttpClientConfigEntity", b =>
                {
                    b.HasOne("Yarp.EfCore.Configuration.Entities.WebProxyConfigEntity", "WebProxy")
                        .WithMany()
                        .HasForeignKey("WebProxyId");

                    b.Navigation("WebProxy");
                });

            modelBuilder.Entity("Yarp.EfCore.Configuration.Entities.ProxyConfigEntity", b =>
                {
                    b.HasOne("Yarp.EfCore.Configuration.Entities.RouteConfigEntity", "RouteConfig")
                        .WithMany()
                        .HasForeignKey("RouteConfigId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RouteConfig");
                });

            modelBuilder.Entity("Yarp.EfCore.Configuration.Entities.RouteConfigEntity", b =>
                {
                    b.HasOne("Yarp.EfCore.Configuration.Entities.RouteMatchEntity", "Match")
                        .WithMany()
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Match");
                });

            modelBuilder.Entity("Yarp.EfCore.Configuration.Entities.RouteConfigMetadataEntity", b =>
                {
                    b.HasOne("Yarp.EfCore.Configuration.Entities.RouteConfigEntity", null)
                        .WithMany("Metadata")
                        .HasForeignKey("RouteConfigEntityId");
                });

            modelBuilder.Entity("Yarp.EfCore.Configuration.Entities.RouteHeaderEntity", b =>
                {
                    b.HasOne("Yarp.EfCore.Configuration.Entities.RouteMatchEntity", null)
                        .WithMany("Headers")
                        .HasForeignKey("RouteMatchEntityId");
                });

            modelBuilder.Entity("Yarp.EfCore.Configuration.Entities.RouteQueryParameterEntity", b =>
                {
                    b.HasOne("Yarp.EfCore.Configuration.Entities.RouteMatchEntity", null)
                        .WithMany("QueryParameters")
                        .HasForeignKey("RouteMatchEntityId");
                });

            modelBuilder.Entity("Yarp.EfCore.Configuration.Entities.SessionAffinityConfigEntity", b =>
                {
                    b.HasOne("Yarp.EfCore.Configuration.Entities.SessionAffinityCookieConfigEntity", "Cookie")
                        .WithMany()
                        .HasForeignKey("CookieId");

                    b.Navigation("Cookie");
                });

            modelBuilder.Entity("Yarp.EfCore.Configuration.Entities.TransformConfigEntity", b =>
                {
                    b.HasOne("Yarp.EfCore.Configuration.Entities.TransformEntity", null)
                        .WithMany("TransformConfigs")
                        .HasForeignKey("TransformEntityId");
                });

            modelBuilder.Entity("Yarp.EfCore.Configuration.Entities.TransformEntity", b =>
                {
                    b.HasOne("Yarp.EfCore.Configuration.Entities.RouteConfigEntity", "RouteConfig")
                        .WithMany("Transforms")
                        .HasForeignKey("RouteConfigId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RouteConfig");
                });

            modelBuilder.Entity("Yarp.EfCore.Configuration.Entities.ClusterConfigEntity", b =>
                {
                    b.Navigation("Destinations");

                    b.Navigation("Metadata");
                });

            modelBuilder.Entity("Yarp.EfCore.Configuration.Entities.DestinationConfigEntity", b =>
                {
                    b.Navigation("Metadata");
                });

            modelBuilder.Entity("Yarp.EfCore.Configuration.Entities.RouteConfigEntity", b =>
                {
                    b.Navigation("Metadata");

                    b.Navigation("Transforms");
                });

            modelBuilder.Entity("Yarp.EfCore.Configuration.Entities.RouteMatchEntity", b =>
                {
                    b.Navigation("Headers");

                    b.Navigation("QueryParameters");
                });

            modelBuilder.Entity("Yarp.EfCore.Configuration.Entities.TransformEntity", b =>
                {
                    b.Navigation("TransformConfigs");
                });
#pragma warning restore 612, 618
        }
    }
}
