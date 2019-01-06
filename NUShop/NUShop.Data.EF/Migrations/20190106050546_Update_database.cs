using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NUShop.Data.EF.Migrations
{
    public partial class Update_database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Announcements_AppUsers_UserId",
                table: "Announcements");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductQuantities_Sizes_ColorId",
                table: "ProductQuantities");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductQuantities_Colors_ColorId1",
                table: "ProductQuantities");

            migrationBuilder.DropTable(
                name: "Advertistments");

            migrationBuilder.DropTable(
                name: "Pages");

            migrationBuilder.DropTable(
                name: "AdvertistmentPositions");

            migrationBuilder.DropTable(
                name: "AdvertistmentPages");

            migrationBuilder.DropIndex(
                name: "IX_ProductQuantities_ColorId1",
                table: "ProductQuantities");

            migrationBuilder.DropIndex(
                name: "IX_Announcements_UserId",
                table: "Announcements");

            migrationBuilder.DropColumn(
                name: "ColorId1",
                table: "ProductQuantities");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Announcements");

            migrationBuilder.CreateTable(
                name: "SinglePages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Alias = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SinglePages", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductQuantities_SizeId",
                table: "ProductQuantities",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncementUsers_UserId",
                table: "AnnouncementUsers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnnouncementUsers_AppUsers_UserId",
                table: "AnnouncementUsers",
                column: "UserId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductQuantities_Colors_ColorId",
                table: "ProductQuantities",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductQuantities_Sizes_SizeId",
                table: "ProductQuantities",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnnouncementUsers_AppUsers_UserId",
                table: "AnnouncementUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductQuantities_Colors_ColorId",
                table: "ProductQuantities");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductQuantities_Sizes_SizeId",
                table: "ProductQuantities");

            migrationBuilder.DropTable(
                name: "SinglePages");

            migrationBuilder.DropIndex(
                name: "IX_ProductQuantities_SizeId",
                table: "ProductQuantities");

            migrationBuilder.DropIndex(
                name: "IX_AnnouncementUsers_UserId",
                table: "AnnouncementUsers");

            migrationBuilder.AddColumn<int>(
                name: "ColorId1",
                table: "ProductQuantities",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Announcements",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "AdvertistmentPages",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertistmentPages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Alias = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdvertistmentPositions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    PageId = table.Column<string>(type: "varchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertistmentPositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdvertistmentPositions_AdvertistmentPages_PageId",
                        column: x => x.PageId,
                        principalTable: "AdvertistmentPages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Advertistments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<string>(type: "varchar(255)", nullable: false),
                    DateModified = table.Column<string>(type: "varchar(255)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    Image = table.Column<string>(type: "varchar(255)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    PositionId = table.Column<string>(type: "varchar(255)", nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    URL = table.Column<string>(type: "varchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertistments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Advertistments_AdvertistmentPositions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "AdvertistmentPositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductQuantities_ColorId1",
                table: "ProductQuantities",
                column: "ColorId1");

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_UserId",
                table: "Announcements",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvertistmentPositions_PageId",
                table: "AdvertistmentPositions",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_Advertistments_PositionId",
                table: "Advertistments",
                column: "PositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Announcements_AppUsers_UserId",
                table: "Announcements",
                column: "UserId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductQuantities_Sizes_ColorId",
                table: "ProductQuantities",
                column: "ColorId",
                principalTable: "Sizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductQuantities_Colors_ColorId1",
                table: "ProductQuantities",
                column: "ColorId1",
                principalTable: "Colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
