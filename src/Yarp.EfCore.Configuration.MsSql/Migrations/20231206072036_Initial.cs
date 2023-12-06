using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yarp.EfCore.Configuration.MsSql.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActiveHealthCheckConfigs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enabled = table.Column<bool>(type: "bit", nullable: true),
                    Interval = table.Column<TimeSpan>(type: "time", nullable: true),
                    Timeout = table.Column<TimeSpan>(type: "time", nullable: true),
                    Policy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActiveHealthCheckConfigs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DestinationConfigs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Health = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Host = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DestinationConfigs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ForwarderRequestConfigs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityTimeout = table.Column<TimeSpan>(type: "time", nullable: true),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VersionPolicy = table.Column<int>(type: "int", nullable: true),
                    AllowResponseBuffering = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForwarderRequestConfigs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PassiveHealthCheckConfigs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enabled = table.Column<bool>(type: "bit", nullable: true),
                    Policy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReactivationPeriod = table.Column<TimeSpan>(type: "time", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassiveHealthCheckConfigs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RouteMatches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Methods = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hosts = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteMatches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SessionAffinityCookieConfigs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Domain = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HttpOnly = table.Column<bool>(type: "bit", nullable: true),
                    SecurePolicy = table.Column<int>(type: "int", nullable: true),
                    SameSite = table.Column<int>(type: "int", nullable: true),
                    Expiration = table.Column<TimeSpan>(type: "time", nullable: true),
                    MaxAge = table.Column<TimeSpan>(type: "time", nullable: true),
                    IsEssential = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionAffinityCookieConfigs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WebProxyConfigs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BypassOnLocal = table.Column<bool>(type: "bit", nullable: true),
                    UseDefaultCredentials = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebProxyConfigs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DestinationConfigMetadata",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DestinationConfigEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DestinationConfigMetadata", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DestinationConfigMetadata_DestinationConfigs_DestinationConfigEntityId",
                        column: x => x.DestinationConfigEntityId,
                        principalTable: "DestinationConfigs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HealthCheckConfigs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PassiveId = table.Column<int>(type: "int", nullable: true),
                    ActiveId = table.Column<int>(type: "int", nullable: true),
                    AvailableDestinationsPolicy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthCheckConfigs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HealthCheckConfigs_ActiveHealthCheckConfigs_ActiveId",
                        column: x => x.ActiveId,
                        principalTable: "ActiveHealthCheckConfigs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HealthCheckConfigs_PassiveHealthCheckConfigs_PassiveId",
                        column: x => x.PassiveId,
                        principalTable: "PassiveHealthCheckConfigs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RouteConfigs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RouteId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatchId = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: true),
                    ClusterId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorizationPolicy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorsPolicy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxRequestBodySize = table.Column<long>(type: "bigint", nullable: true),
                    RateLimiterPolicy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeoutPolicy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Timeout = table.Column<TimeSpan>(type: "time", nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteConfigs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RouteConfigs_RouteMatches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "RouteMatches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RouteHeaders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Values = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mode = table.Column<int>(type: "int", nullable: false),
                    IsCaseSensitive = table.Column<bool>(type: "bit", nullable: false),
                    RouteMatchEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteHeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RouteHeaders_RouteMatches_RouteMatchEntityId",
                        column: x => x.RouteMatchEntityId,
                        principalTable: "RouteMatches",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RouteQueryParameters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Values = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mode = table.Column<int>(type: "int", nullable: false),
                    IsCaseSensitive = table.Column<bool>(type: "bit", nullable: false),
                    RouteMatchEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteQueryParameters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RouteQueryParameters_RouteMatches_RouteMatchEntityId",
                        column: x => x.RouteMatchEntityId,
                        principalTable: "RouteMatches",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SessionAffinityConfigs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enabled = table.Column<bool>(type: "bit", nullable: true),
                    Policy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FailurePolicy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AffinityKeyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CookieId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionAffinityConfigs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SessionAffinityConfigs_SessionAffinityCookieConfigs_CookieId",
                        column: x => x.CookieId,
                        principalTable: "SessionAffinityCookieConfigs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HttpClientConfigs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SslProtocols = table.Column<int>(type: "int", nullable: true),
                    DangerousAcceptAnyServerCertificate = table.Column<bool>(type: "bit", nullable: true),
                    MaxConnectionsPerServer = table.Column<int>(type: "int", nullable: true),
                    WebProxyId = table.Column<int>(type: "int", nullable: true),
                    EnableMultipleHttp2Connections = table.Column<bool>(type: "bit", nullable: true),
                    RequestHeaderEncoding = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HttpClientConfigs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HttpClientConfigs_WebProxyConfigs_WebProxyId",
                        column: x => x.WebProxyId,
                        principalTable: "WebProxyConfigs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RouteConfigMetadata",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RouteConfigEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteConfigMetadata", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RouteConfigMetadata_RouteConfigs_RouteConfigEntityId",
                        column: x => x.RouteConfigEntityId,
                        principalTable: "RouteConfigs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Transforms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RouteConfigId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transforms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transforms_RouteConfigs_RouteConfigId",
                        column: x => x.RouteConfigId,
                        principalTable: "RouteConfigs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClusterConfigs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClusterId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoadBalancingPolicy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SessionAffinityId = table.Column<int>(type: "int", nullable: true),
                    HealthCheckId = table.Column<int>(type: "int", nullable: true),
                    HttpClientId = table.Column<int>(type: "int", nullable: true),
                    HttpRequestId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClusterConfigs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClusterConfigs_ForwarderRequestConfigs_HttpRequestId",
                        column: x => x.HttpRequestId,
                        principalTable: "ForwarderRequestConfigs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ClusterConfigs_HealthCheckConfigs_HealthCheckId",
                        column: x => x.HealthCheckId,
                        principalTable: "HealthCheckConfigs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ClusterConfigs_HttpClientConfigs_HttpClientId",
                        column: x => x.HttpClientId,
                        principalTable: "HttpClientConfigs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ClusterConfigs_SessionAffinityConfigs_SessionAffinityId",
                        column: x => x.SessionAffinityId,
                        principalTable: "SessionAffinityConfigs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TransformConfigs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransformEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransformConfigs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransformConfigs_Transforms_TransformEntityId",
                        column: x => x.TransformEntityId,
                        principalTable: "Transforms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ClusterConfigsDestinations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClusterConfigId = table.Column<int>(type: "int", nullable: false),
                    DestinationConfigId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClusterConfigsDestinations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClusterConfigsDestinations_ClusterConfigs_ClusterConfigId",
                        column: x => x.ClusterConfigId,
                        principalTable: "ClusterConfigs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClusterConfigsDestinations_DestinationConfigs_DestinationConfigId",
                        column: x => x.DestinationConfigId,
                        principalTable: "DestinationConfigs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClusterConfigsMetadata",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClusterConfigEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClusterConfigsMetadata", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClusterConfigsMetadata_ClusterConfigs_ClusterConfigEntityId",
                        column: x => x.ClusterConfigEntityId,
                        principalTable: "ClusterConfigs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClusterConfigs_HealthCheckId",
                table: "ClusterConfigs",
                column: "HealthCheckId");

            migrationBuilder.CreateIndex(
                name: "IX_ClusterConfigs_HttpClientId",
                table: "ClusterConfigs",
                column: "HttpClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClusterConfigs_HttpRequestId",
                table: "ClusterConfigs",
                column: "HttpRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_ClusterConfigs_SessionAffinityId",
                table: "ClusterConfigs",
                column: "SessionAffinityId");

            migrationBuilder.CreateIndex(
                name: "IX_ClusterConfigsDestinations_ClusterConfigId",
                table: "ClusterConfigsDestinations",
                column: "ClusterConfigId");

            migrationBuilder.CreateIndex(
                name: "IX_ClusterConfigsDestinations_DestinationConfigId",
                table: "ClusterConfigsDestinations",
                column: "DestinationConfigId");

            migrationBuilder.CreateIndex(
                name: "IX_ClusterConfigsMetadata_ClusterConfigEntityId",
                table: "ClusterConfigsMetadata",
                column: "ClusterConfigEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_DestinationConfigMetadata_DestinationConfigEntityId",
                table: "DestinationConfigMetadata",
                column: "DestinationConfigEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthCheckConfigs_ActiveId",
                table: "HealthCheckConfigs",
                column: "ActiveId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthCheckConfigs_PassiveId",
                table: "HealthCheckConfigs",
                column: "PassiveId");

            migrationBuilder.CreateIndex(
                name: "IX_HttpClientConfigs_WebProxyId",
                table: "HttpClientConfigs",
                column: "WebProxyId");

            migrationBuilder.CreateIndex(
                name: "IX_RouteConfigMetadata_RouteConfigEntityId",
                table: "RouteConfigMetadata",
                column: "RouteConfigEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_RouteConfigs_MatchId",
                table: "RouteConfigs",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_RouteHeaders_RouteMatchEntityId",
                table: "RouteHeaders",
                column: "RouteMatchEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_RouteQueryParameters_RouteMatchEntityId",
                table: "RouteQueryParameters",
                column: "RouteMatchEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionAffinityConfigs_CookieId",
                table: "SessionAffinityConfigs",
                column: "CookieId");

            migrationBuilder.CreateIndex(
                name: "IX_TransformConfigs_TransformEntityId",
                table: "TransformConfigs",
                column: "TransformEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Transforms_RouteConfigId",
                table: "Transforms",
                column: "RouteConfigId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClusterConfigsDestinations");

            migrationBuilder.DropTable(
                name: "ClusterConfigsMetadata");

            migrationBuilder.DropTable(
                name: "DestinationConfigMetadata");

            migrationBuilder.DropTable(
                name: "RouteConfigMetadata");

            migrationBuilder.DropTable(
                name: "RouteHeaders");

            migrationBuilder.DropTable(
                name: "RouteQueryParameters");

            migrationBuilder.DropTable(
                name: "TransformConfigs");

            migrationBuilder.DropTable(
                name: "ClusterConfigs");

            migrationBuilder.DropTable(
                name: "DestinationConfigs");

            migrationBuilder.DropTable(
                name: "Transforms");

            migrationBuilder.DropTable(
                name: "ForwarderRequestConfigs");

            migrationBuilder.DropTable(
                name: "HealthCheckConfigs");

            migrationBuilder.DropTable(
                name: "HttpClientConfigs");

            migrationBuilder.DropTable(
                name: "SessionAffinityConfigs");

            migrationBuilder.DropTable(
                name: "RouteConfigs");

            migrationBuilder.DropTable(
                name: "ActiveHealthCheckConfigs");

            migrationBuilder.DropTable(
                name: "PassiveHealthCheckConfigs");

            migrationBuilder.DropTable(
                name: "WebProxyConfigs");

            migrationBuilder.DropTable(
                name: "SessionAffinityCookieConfigs");

            migrationBuilder.DropTable(
                name: "RouteMatches");
        }
    }
}
