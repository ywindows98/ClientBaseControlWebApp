using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClientBaseControlWebApp.Data.Migrations
{
    public partial class AddDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProcedureRecords_ProcedureType_ProcedureTypeId",
                table: "ProcedureRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProcedureType",
                table: "ProcedureType");

            migrationBuilder.RenameTable(
                name: "ProcedureType",
                newName: "ProcedureTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProcedureTypes",
                table: "ProcedureTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProcedureRecords_ProcedureTypes_ProcedureTypeId",
                table: "ProcedureRecords",
                column: "ProcedureTypeId",
                principalTable: "ProcedureTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProcedureRecords_ProcedureTypes_ProcedureTypeId",
                table: "ProcedureRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProcedureTypes",
                table: "ProcedureTypes");

            migrationBuilder.RenameTable(
                name: "ProcedureTypes",
                newName: "ProcedureType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProcedureType",
                table: "ProcedureType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProcedureRecords_ProcedureType_ProcedureTypeId",
                table: "ProcedureRecords",
                column: "ProcedureTypeId",
                principalTable: "ProcedureType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
