using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClientBaseControlWebApp.Data.Migrations
{
    public partial class ChangeRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Appearances_AppearanceId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_AppearanceId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "AppearanceId",
                table: "Clients");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Appearances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Appearances_ClientId",
                table: "Appearances",
                column: "ClientId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Appearances_Clients_ClientId",
                table: "Appearances",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appearances_Clients_ClientId",
                table: "Appearances");

            migrationBuilder.DropIndex(
                name: "IX_Appearances_ClientId",
                table: "Appearances");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Appearances");

            migrationBuilder.AddColumn<int>(
                name: "AppearanceId",
                table: "Clients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_AppearanceId",
                table: "Clients",
                column: "AppearanceId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Appearances_AppearanceId",
                table: "Clients",
                column: "AppearanceId",
                principalTable: "Appearances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
