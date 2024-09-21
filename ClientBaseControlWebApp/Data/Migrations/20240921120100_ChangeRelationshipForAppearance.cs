using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClientBaseControlWebApp.Data.Migrations
{
    public partial class ChangeRelationshipForAppearance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Appearances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Appearances_ClientId",
                table: "Appearances",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appearances_Clients_ClientId",
                table: "Appearances",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
