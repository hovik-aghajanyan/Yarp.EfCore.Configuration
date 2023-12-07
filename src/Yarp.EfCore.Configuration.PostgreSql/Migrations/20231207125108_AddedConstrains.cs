using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yarp.EfCore.Configuration.PostgreSql.Migrations
{
    /// <inheritdoc />
    public partial class AddedConstrains : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_RouteConfigs_RouteId",
                table: "RouteConfigs",
                column: "RouteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClusterConfigs_ClusterId",
                table: "ClusterConfigs",
                column: "ClusterId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RouteConfigs_RouteId",
                table: "RouteConfigs");

            migrationBuilder.DropIndex(
                name: "IX_ClusterConfigs_ClusterId",
                table: "ClusterConfigs");
        }
    }
}
