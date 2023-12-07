using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yarp.EfCore.Configuration.MsSql.Migrations
{
    /// <inheritdoc />
    public partial class AddedConstrains : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RouteId",
                table: "RouteConfigs",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ClusterId",
                table: "ClusterConfigs",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

            migrationBuilder.AlterColumn<string>(
                name: "RouteId",
                table: "RouteConfigs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ClusterId",
                table: "ClusterConfigs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
