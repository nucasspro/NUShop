using Microsoft.EntityFrameworkCore.Migrations;

namespace NUShop.Data.EF.Migrations
{
    public partial class Update_Table_Name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactDetails",
                table: "ContactDetails");

            migrationBuilder.RenameTable(
                name: "ContactDetails",
                newName: "Contacts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts");

            migrationBuilder.RenameTable(
                name: "Contacts",
                newName: "ContactDetails");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactDetails",
                table: "ContactDetails",
                column: "Id");
        }
    }
}
