using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UeLib.Migrations
{
    public partial class ManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Assets_AssetId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_AssetId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "AssetId",
                table: "Tags");

            migrationBuilder.CreateTable(
                name: "AssetTag",
                columns: table => new
                {
                    AssetsId = table.Column<int>(type: "INTEGER", nullable: false),
                    TagsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetTag", x => new { x.AssetsId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_AssetTag_Assets_AssetsId",
                        column: x => x.AssetsId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetTag_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssetTag_TagsId",
                table: "AssetTag",
                column: "TagsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssetTag");

            migrationBuilder.AddColumn<int>(
                name: "AssetId",
                table: "Tags",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_AssetId",
                table: "Tags",
                column: "AssetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Assets_AssetId",
                table: "Tags",
                column: "AssetId",
                principalTable: "Assets",
                principalColumn: "Id");
        }
    }
}
